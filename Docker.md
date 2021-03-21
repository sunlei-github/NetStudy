[Toc]

---

### Docker基础命令

#### run

```shell
docker run  --name testcentos -it --restart=always centos   /bin/bash 
#运行一个centos容器，如果本地没有centos镜像则拉取最新的镜像。
#-i 以交互式方式运行该镜像
#-t 打开一个虚拟终端
#--name  后面是容器的名称
#/bin/bash  指定终端的命令是以/bin/bash 运行的
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





