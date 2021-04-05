[Toc]

---

### 什么是Docker镜像

![1616501121931](D:\学习\vsProject\Study\NetStudy\1616501121931.png)

Docker最底层是一个bootfs(文件引导系统)，当一个容器启动的时候，镜像会被移动到内存中，而bootfs会被卸载。

第二层是一个root文件系统（rootfs）。当一个容器启动的时候，他只会以只读的方式，使用联合加载（union mount）技术加载它的子级文件系统（联合文件系统），联合加载会将各层文件系统叠加在一起，这样最终的文件系统就会包含所有的文件和目录。

Docker将这样的文件系统称为镜像，一个镜像可以放到另一个镜像的顶部，位于下面的镜像叫做父镜像，最底部的镜像叫做基础镜像。当镜像启动容器的时候，Docker会在该镜像的最顶层添加一层读写文件系统，Docker中运行的程序就是在这个读写层进行操作的。

当Docker第一次启动容器的时候，初始的读写层是空的，当文件系统发生变化时，会将要修改的文件从只读层复制到读写层，该文件的读写版本依然存在，但是已经被读写层的该文件副本所覆盖，这种机制被称为写时复制（copy on write）

**所有的本地镜像都保存的在  /var/lib/docker 目录下**

### Docker基础命令

#### run

```shell
docker run  --name testcentos -it --restart=always centos   /bin/bash 
#运行一个centos容器，如果本地没有centos镜像则拉取最新的镜像。
#-i 以交互式方式运行该镜像
#-t 打开一个虚拟终端
#--name  后面是容器的名称
#/bin/bash  指定终端的命令是以/bin/bash 运行的
#-p 暴露端口 80:80
#-P 绑定一个随机宿主机端口
#-d 以后台方式运行
#--restart 自动重启 参数有
#	always 总是重启 无论容器是如何退出的
#	on-failure 只有当容器退出代码为非0时 才重启
# 	--restart=on-failure：5 自动重启的次数 如果重启失败
```

```shell
cat /etc/hosts 
# 查看容器的基本信息
```

#### search

```shell
docker search centos
#搜索一个centos镜像
```

#### pull

``` shell
docker pull centos
#拉取一个centos 镜像到本地
```

#### ps 

```shell
docker ps 
#列出所有正在容器
#-a 列出所有的容器包括停止运行的容器
#-q 只是列出Id
```

#### images

```shell
docker images -aq
# 列出镜像
#-a 全部的镜像
#-q 只列出镜像Id
```

#### start

```shell
docker start testcentos 
#start 后面可以跟容器Id 或者容器名称
```

#### create

``` shell
docker create centos 
#create 创建一个镜像 但是不运行
```

#### logs

```shell
docker logs -f -t testcentos
# 查看容器运行的日志 参数可以是 容器Id或者是名称
#-f 追踪式打印日志
#-t 为日志加上时间戳
docker logs --tail 10 testcentos 
# 查看日志最新的10条日志 0 则是查看最新的日志
```

#### top

```shell
docker top testcentos
# 查看容器的进程 参数可以是容器名称也可以是容器Id
```

#### stats

```shell
docker stats testcentos
# 查看容器的统计信息 包括CPU 内存 IO 等
```

#### exec

```shell
docker exec -it testcentos /bin/bash
# 进入一个正在运行的容器 可以是容器名称也可以是容器Id
```

#### stop

```shell
docker stop testcentos
# 停止一个正在运行的容器
```

#### kill

```shell
docker kill testcentos
# 快速杀死一个正在运行的容器
```

#### inspect

```shell
docker inspect testcentos 
# 查看容器元数据 包含运行状态 镜像 挂载卷等
```

#### rm(rmi)

```shell
docker rm -f testcentos
# 删除容器 可以是容器名称也可以是镜像Id
#-f 强制删除
docker rm $(docker ps -aq)
#删除所有的容器
docker rmi $(docker images -aq)
#删除所有的镜像
```

#### login

``` shell
docker login 
#登陆对应的仓库 默认是dockerHub
#-u 用户名 -p 用户名密码
```

#### tag

```shell
docker tag centos:qwe postive/mtcentos:v1
# 将一个现有的镜像 打上一个标签生成一个新的镜像
```

#### push

```shell
docker push postive/mtcentos:v1
# 推送镜像到dockerHub 需要注意的是 被推送的镜像的名称格式是 登陆的用户名/镜像名称:标签名称
```

#### commit

``` shell
docker commit -m "testtest" -a "own own" ae8 postive/mycentos:ownlasteat
# 将一个容器打包成镜像
# -m 是打包镜像的一些信息
# -a 是镜像的作者信息
# 最后一个参数是打包的仓库 ： 之后是镜像的标签
```

#### history

``` shell
docker history 44f
# 查看一个镜像的构建历史
```

#### port

```shell
docker port 2d22 80
# 查看容器80的端口映射到宿主机是哪个端口
```



### Dockerfile 

Dockerfile 是由一系列的命令和参数组成的，每条指令，比如FROM 必须大写，而且后面需要添加一个参数，Dockerfile中的指令会按顺序从上到下去执行。

#### FROM

每个Dockerfile文件的第一条指令都必须是FROM，FROM指令指定一个已经存在的镜像，Dockfile之后所有的指令都基于该指令运行，这个镜像被称为基础镜像。

#### MAINTAINER

MAINTINER 指定的是这个镜像的作者信息。

#### RUN

RUN 一般被用来在build镜像之前运行命令。

比如：运行exec(数组语法)格式的命令：RUN ["agt-get","install","-y","nginx"]

#### CMD

CMD指令一般被用来在在启动容器时运行的命令。

Dockerfile文件中一般只有一条CMD命令，如果有多条CMD命令也只有最后一条CMD命令生效。

#### ENTRYPOINT 

ENTRYPOINT指令与CMD命令类似，但是run容器的时候后面的参数可以追加到ENTRYPOINT命令后面，形成动态的组合命令。

**docker run 的时候可以使用 --entrypoint 指令覆盖ENTRYPOINT指令**

#### WORKDIR

WORKDIR指令用来从镜像创建一个新容器时，在容器内部设置一个工作目录，ENTRYPOINT和CMD都会在这个目录里面执行，这个指令也可以为最终的容器设置工作目录。

**docker run 的时候可以使用 -w 指令覆盖工作目录**

#### ENV

环境变量



###  daemon.json 文件

docker安装后默认没有daemon.json这个配置文件，需要进行手动创建。配置文件的默认路径：/etc/docker/daemon.json 

[官方地址](https://docs.docker.com/engine/reference/commandline/dockerd/#daemon-configuration-file)

```shell

{
	#镜像加速的地址，增加后在 docker info中可查看
   "registry-mirrors":[
           "https://hub-mirror.c.163.com",
    	   "https://mirror.baidubce.com"
    ],
	#配置docker的私库地址
    "insecure-registries": [
       "https://ower.site.com"
    ]，
}
```

