# DotNetCore.DDD.Template
本项目为基于.Net Core 3.1 的 DDD（领域驱动设计） 模板

## DDD分层
![avatar](https://github.com/cailin0630/DotNetCore.DDD.Template/blob/main/ddd-jiangyi.png)

## CQRS图解
![avatar](https://github.com/cailin0630/DotNetCore.DDD.Template/blob/main/cqrs.jpg)

## Code First 
dotnet ef migrations add InitialCreate
> https://itnext.io/asp-net-core-3-1-entity-framework-core-with-postgresql-with-code-first-approach-33b102e1734f


# DDD-微服务架构实践-1

<a name="021ac975"></a>
# 价值

<br />近几年随着微服务的流行，**领域驱动设计(Domain-Driven Design)** 重新回到了主流视野中。当我们面对基于关系型数据库的 CRUD 系统，面对繁琐的业务规则，以及未来不可知的业务变化时，就可以尝试使用DDD。<br />
<br />DDD 的核心价值就是解决这类复杂系统的设计(至少它是这么宣称的)，如果你能理解并掌握 DDD 的话，在面对一个复杂的业务系统需求时应该能够给出一个合理、可行，具备可维护性与扩展性的设计方案。<br />

<a name="4920095f"></a>
# 如何分层


<a name="6e21706f"></a>
## 与传统架构相比

<br />「分层」是广大开发者最熟悉的架构模式之一，在 DDD 中也有分层的概念，与传统的三层架构有以下差异。<br />

- 用**Application层**的**Handlers**替代了传统的**BLL层**（Business Logic Layer ）
- 用**Domain层**的**Repositories**替代了传统的**DAL层**（Data Access Layer）
- 多了CQRS
- 多了DomainEvent
- ...



> 对于分层，Eric Evans 的书中给出了一些说明：
> - 首先层与层之间的依赖关系是单向的，是自上而下的
> - 其次 Application 与 Domain 是实现业务规则的核心



<a name="6595d37a"></a>
## 分层介绍

<br />如下图所示，为本章节所介绍的分层<br />
<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173166347-ea0775a8-0abc-45b4-a8d0-662055f4ad5a.png#align=left&display=inline&height=471&margin=%5Bobject%20Object%5D&name=image.png&originHeight=942&originWidth=1224&size=96537&status=done&style=none&width=612)<br />
<br />github模版项目地址<br />
<br />[![](https://cdn.nlark.com/yuque/0/2020/svg/2688469/1605858001807-910370c5-2483-43ac-900d-a3a52bd29ccc.svg#align=left&display=inline&height=120&margin=%5Bobject%20Object%5D&originHeight=120&originWidth=400&size=0&status=done&style=none&width=400)](https://github.com/cailin0630/DotNetCore.DDD.Template)<br />

<a name="358640d5"></a>
### API（接口层）


- Controllers


<br />API 层是整个系统对外暴露服务的部分，可以是 REST ，也可以是 gRPC 等。API 层的工作是基于协议对客户端提供的数据进行校验，然后通常将数据转化为 Application 层所需的 DTO 对象，并调用 Application 提供的服务，最后将结果返回给调用方。API 中不应该有任何的业务规则与逻辑，只是完成数据对象的转换。<br />

<a name="fcb5ace3"></a>
### Application（应用层）


- QueryHandlers（查询处理器）
- CommandHandlers（命令处理器）
- DomainEventHandlers（领域事件处理器）
- DTO


<br />这一层不应该涉及到复杂，核心的业务逻辑，而是对下层的 Domain (领域层)进行协调，对业务逻辑进行编排。这一层只应该依赖于下层的 Domain层与 Infrastructure层。<br />

<a name="b895125e"></a>
### Domain（领域层）


- Repositories（数据仓储）
- Aggregations（聚合根/实体/值对象）
- Events（领域事件）


<br />Domain 是 DDD 的核心层。Repositories定义了领域对象对应的仓库，Aggregations定义了聚合根/实体/值对象等领域对象，Events定义了领域事件。这一层有大量的基于领域对象的业务逻辑处理以及对数据库的CRUD的操作。这一层只应该依赖与下层的Infrastructure层。<br />

<a name="6b4ec495"></a>
### Infrastructure（基础设施层）


- Core（Repositories依赖的范型仓储）
- Abstractions（Aggregations依赖的抽象类和接口）
- Extensions（一些扩展方法）
- ...



<a name="da3fc2c6"></a>
# CQRS 与 MediatR


<a name="CQRS"></a>
## CQRS

<br />CQRS — Command Query Responsibility Segregation，故名思义是将 Command 与 Query 分离的一种模式。<br />
<br />CQRS 将系统中的操作分为两类，即「命令」(Command) 与「查询」(Query)。命令则是对会引起数据发生变化操作的总称，即新增，更新，删除这些操作，都是命令。查询则和字面意思一样，即不会对数据产生变化的操作，只是按照某些条件查找数据。<br />
<br />一般情况下，CQRS的核心思想是将读和写的数据存储在不同的库里，降低由于读写造成的互相影响，一定程度上可以提高高并发时的系统稳定性。<br />
<br />而当没有从数据库角度读写分离的需求时，也可以借助CQRS思想，进行代码层面的读写分离，降低耦合，提高代码可维护性。<br />
<br />通常在实现CQRS时，可以使用MediatR提供的命令和中介者模式。<br />

<a name="MediatR"></a>
## MediatR


<a name="46991287"></a>
### 中介者模式

<br />在介绍 MediatR 之前，先简单了解下中介者模式。中介者模式主要是指定义一个中介对象来调度一系列对象之间的交互关系，各对象之间不需要显式的相互引用，降低耦合性。如下对比图（普通模式与中介者模式的区别）：<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173240127-3faa6834-e29f-4b45-bab6-9bcefd0c9de7.png#align=left&display=inline&height=174&margin=%5Bobject%20Object%5D&name=image.png&originHeight=347&originWidth=962&size=40204&status=done&style=none&width=481)<br />

<a name="afff3d4b"></a>
### MediatR介绍

<br />通常，在API层与Application之间，建立消息模型，通过发送消息到对应的处理器来交互。根据消息执行机制可以分为**单播消息**和**多播消息**。<br />
<br />下图展示了MediatR的消息管道<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173252592-69dc659a-52da-4482-9dbc-edd4038e7354.png#align=left&display=inline&height=300&margin=%5Bobject%20Object%5D&name=image.png&originHeight=600&originWidth=1276&size=53154&status=done&style=none&width=638)<br />

- 单播消息


<br />在Controllers与Command/Query Handlers之间进行消息传递时，通常只有一个处理器来处理来自Controllers的消息，所以此处使用单播消息。<br />

> 当一个query或者command有多个处理器时，只执行第一个处理器


<br />发送单播消息<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173278354-e6401501-06d4-4f5c-af83-99a31cdc8efe.png#align=left&display=inline&height=103&margin=%5Bobject%20Object%5D&name=image.png&originHeight=205&originWidth=941&size=26345&status=done&style=none&width=470.5)<br />处理单播消息<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173287168-5502179d-7473-4fc2-a8f9-5670d5af4d69.png#align=left&display=inline&height=152&margin=%5Bobject%20Object%5D&name=image.png&originHeight=303&originWidth=1097&size=56401&status=done&style=none&width=548.5)<br />

- 多播消息


<br />在CommandHandlers与EventHandlers之间进行领域事件消息传递时，通常会有多个处理器来处理领域事件消息，所以此处使用多播消息。<br />

> 当一个领域事件有多个处理器时，是按代码顺序依次执行的


<br />发送多播消息<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173308546-a0fcecb2-c19a-42d6-9b4a-d8e70cb7b130.png#align=left&display=inline&height=247&margin=%5Bobject%20Object%5D&name=image.png&originHeight=493&originWidth=1121&size=118792&status=done&style=none&width=560.5)<br />处理多播消息<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173316939-92338a6d-8904-4ad9-bf73-0b6d88615f68.png#align=left&display=inline&height=160&margin=%5Bobject%20Object%5D&name=image.png&originHeight=320&originWidth=1022&size=58377&status=done&style=none&width=511)<br />

<a name="685d63fe"></a>
# Entity 与 Value Object

<br />当采用EntityFramework Code First模式对系统进行建模时，我们需要根据业务需求来设计**业务对象**，而这些业务对象就是 DDD 中 Entity 与 Value Object 的基础。<br />在 DDD 中，实体和值对象是很基础的领域对象。实体一般对应业务对象，它具有业务属性和业务行为；而值对象主要是属性集合，对实体的状态和特征进行描述。<br />

<a name="b21633fc"></a>
## 两者区别


- Entity 是业务逻辑的核心体现（MUST）
- Entity 应该具有唯一的标识
- 相比 Entity 所拥有的数据属性，我们更关注的是它的唯一标识
- Value Object 没有唯一标识
- Value Object 我们更加关注于它的数据属性
- Value Object 不会单独存在，而是附属于某个 Entity
- Value Object 的生命周期会与所附属的 Entity 绑定在一起



<a name="f05aba5b"></a>
## 案例说明

<br />如果要实现以下数据结构的需求，对象Person有唯一标识，姓名、地址等属性，而Address又含有城市、街道等几个属性但无唯一标识，Address是附属于Person的。此时可以把Person看作Entity，把Address看作Value Object。<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173370237-72afee0d-d13d-45e4-8df0-416bb5e13666.png#align=left&display=inline&height=259&margin=%5Bobject%20Object%5D&name=image.png&originHeight=518&originWidth=916&size=45928&status=done&style=none&width=458)<br />
<br />从数据库表结构来看有以下方式<br />

- 不用专门的表去映射一个ValueObject对象，而是用Entity对应表上的几个字段(Person表中Address开头的字段)

![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173381912-e8558ee8-3435-4885-aaed-ddfae1457ed6.png#align=left&display=inline&height=224&margin=%5Bobject%20Object%5D&name=image.png&originHeight=448&originWidth=416&size=30300&status=done&style=none&width=208)<br />

- 使用专门的表去映射ValueObject对象，ValueObject拥有一个指向所属Entity的外键，但是自己没有所谓的业务主键


<br />![image.png](https://cdn.nlark.com/yuque/0/2020/png/2688469/1605173405463-841a4347-9927-463b-896b-34e9ea147c7c.png#align=left&display=inline&height=232&margin=%5Bobject%20Object%5D&name=image.png&originHeight=464&originWidth=934&size=46699&status=done&style=none&width=467)<br />

<a name="Aggregation"></a>
# Aggregate 与 AggregateRoot


<a name="jQy78"></a>
## 聚合（Aggregate）


领域模型内的实体和值对象就好比个体，而能让实体和值对象协同工作的组织就是聚合，它用来确保这些领域对象在实现共同的业务逻辑时，能保证数据的一致性。<br />
<br />你可以这么理解，聚合就是由业务和逻辑紧密关联的实体和值对象组合而成的，聚合是数据修改和持久化的基本单元，每一个聚合对应一个仓储，实现数据的持久化。<br />
<br />聚合有一个聚合根和上下文边界，这个边界根据业务单一职责和高内聚原则，定义了聚合内部应该包含哪些实体和值对象，而聚合之间的边界是松耦合的。按照这种方式设计出来的微服务很自然就是“高内聚、低耦合”的。<br />
<br />聚合在 DDD 分层架构里属于领域层，领域层包含了多个聚合，共同实现核心业务逻辑。聚合内实体以充血模型实现个体业务能力，以及业务逻辑的高内聚。跨多个实体的业务逻辑通过领域服务来实现，跨多个聚合的业务逻辑通过应用服务来实现。比如有的业务场景需要同一个聚合的 A 和 B 两个实体来共同完成，我们就可以将这段业务逻辑用领域服务来实现；而有的业务逻辑需要聚合 C 和聚合 D 中的两个服务共同完成，这时你就可以用应用服务来组合这两个服务。

<a name="OFMV2"></a>
## 聚合根（AggregateRoot）

<br />聚合根的主要目的是为了避免由于复杂数据模型缺少统一的业务规则控制，而导致聚合、实体之间数据不一致性的问题。<br />
<br />传统数据模型中的每一个实体都是对等的，如果任由实体进行无控制地调用和数据修改，很可能会导致实体之间数据逻辑的不一致。而如果采用锁的方式则会增加软件的复杂度，也会降低系统的性能。<br />
<br />如果把聚合比作组织，那聚合根就是这个组织的负责人。聚合根也称为根实体，它不仅是实体，还是聚合的管理者。<br />
<br />首先它作为实体本身，拥有实体的属性和业务行为，实现自身的业务逻辑。<br />
<br />其次它作为聚合的管理者，在聚合内部负责协调实体和值对象按照固定的业务规则协同完成共同的业务逻辑。<br />
<br />最后在聚合之间，它还是聚合对外的接口人，以聚合根 ID 关联的方式接受外部任务和请求，在上下文内实现聚合之间的业务协同。也就是说，聚合之间通过聚合根 ID 关联引用，如果需要访问其它聚合的实体，就要先访问聚合根，再导航到聚合内部实体，外部对象不能直接访问聚合内实体。<br />

<a name="tERyr"></a>
## 聚合的规则


- **规则一：只引用聚合根**

**<br />要求聚合根是聚合中唯一可以由外部类引用的部分，外部只能通过调用聚合根上的方法来更新聚合。<br />**

- **规则二：聚合间的引用必须使用主键**
- **规则三：在一个事务中，只能创建或更新一个聚合**

<br />
<a name="nrZju"></a>
# 贫血模型 与 充血模型


<a name="t4FEu"></a>
## 从传统三层架构看贫血模型

<br />实际上，你可能一直都在用贫血模型做开发。不夸张地讲，目前几乎所有的业务后端系统，都是基于贫血模型的。我们举个简单的例子。
```csharp

////////// Controller //////////
public class UserController 
{
  UserBll _userBll; //通过构造函数或者IOC框架注入
  
  public UserOutput GetUserById(long userId) 
  {
    var userOutput = _userBll.GetUserById(userId);
    return userOutput;
  }
}

////////// DTO //////////
public class UserOutput 
{
  public long Id {get; set;}
  public string Name {get; set;}
  public string Phone {get; set;}
}

////////// BLL//////////
public class UserBll {
  UserDal _userDal; //通过构造函数或者IOC框架注入
  
  public UserOutput GetUserById(long userId)
  {
    var userEntity = _userDal.GetUserById(userId);
    var userOutput = [...convert userEntity to userOutput...];
    return userOutput;
  }
}

////////// DAL //////////
public class UserDal 
{
  public UserEntity GetUserById(long userId) 
  { 
      //... 
  }
}

////////// Entity //////////
public class UserEntity 
{
  public long Id {get; set;}
  public string Name {get; set;}
  public string Phone {get; set;}
}
```
我们平时开发 Web 后端项目的时候，基本上都是这么组织代码的。<br />
<br />其中，UserEntity 和 UserDal 组成了数据访问层，UserOutput 和 UserBll 组成了业务逻辑层，UserOutput 和 UserController 在这里属于接口层。<br />
<br />从代码中，我们可以发现，UserEntity和UserOutput 都是纯粹的数据结构，只包含数据，不包含任何业务逻辑。业务逻辑集中在 UserBll 中。像 UserEntity和UserOutput这样，只包含数据，不包含业务逻辑的类，就叫作**贫血模型（Anemic Domain Model）**。这种贫血模型将数据与操作分离，破坏了面向对象的封装特性，是一种典型的面向过程的编程风格。<br />

<a name="THRkJ"></a>
## 从DDD分层架构看充血模型

<br />在贫血模型中，数据和业务逻辑被分割到不同的类中。**充血模型（Rich Domain Model）**正好相反，数据和对应的业务逻辑被封装到同一个类中。因此，这种充血模型满足面向对象的封装特性，是典型的面向对象编程风格。<br />**<br />实际上，从前面的如何分层介绍可以看出，DDD模式也是按照自上而下的多级分层来设计的。Controller 层还是负责暴露接口，Repository 层还是负责数据存取，Domain 层负责核心业务逻辑。它跟基于贫血模型的传统开发模式的区别主要在 Domain 层。

基于贫血模型的传统的开发模式，**重 BLL 轻 Entity**；<br />基于充血模型的 DDD 开发模式，**轻 Application 重 Domain**。<br />[<br />](https://github.com/cailin0630/DotNetCore.DDD.Template)
<a name="rcq5l"></a>
# 参考资料


- [https://time.geekbang.org/course/detail/100044601-188694](https://time.geekbang.org/course/detail/100044601-188694)
- [https://book.douban.com/subject/25844633/](https://book.douban.com/subject/25844633/)
- [https://www.zhihu.com/column/c_1208715969939640320](https://www.zhihu.com/column/c_1208715969939640320)
- [https://microservices.io/patterns/data/cqrs.html](https://microservices.io/patterns/data/cqrs.html)

