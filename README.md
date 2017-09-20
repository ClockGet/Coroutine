# Coroutine
此项目为协程(Coroutine)简单实例

# 介绍
来自[知乎](http://www.zhihu.com/question/23895384 "知乎")

> Coroutine翻译成协程，它和Process以及Thread的区别是：Coroutine是编译器级的，Process和Thread是操作系统级别的。Process和Thread是os通过调度算法，保存当前的上下文，然后从上次暂停的地方再次开始计算，重新开始的地方不可预期，每次CPU计算的指令数量和代码跑过的CPU时间是相关的，跑到os分配的cpu时间到达后就会被os强制挂起。Coroutine是编译器的魔术，通过插入相关的代码使得代码段能够实现分段式的执行，重新开始的地方是yield关键字指定的，一次一定会跑到一个yield对应的地方。