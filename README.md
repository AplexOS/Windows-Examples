# README

## 文件目录说明

* `C++_lib`：Windows 10可能没有足够的C++库，运行前请安装C++库；
* `Compiled_bin`：已经编译可以运行的软件；
* `dll`：当前软件依赖的dll库；
* `SuperIOCPP`：SuperIO C++操作源代码；

## 当前开发环境

VS2017

## SuperIOCPP使用方法

```
 ***** Usage *****

 SuperIOCPP mode <pin number -- [0:7]> <pin mode -- 0: output, 1: input>
 or
 SuperIOCPP read <pin number>
 or
 SuperIOCPP write <pin number -- [0:7]> <pin value -- 0: high level, 1: low level>
```

上面的`high level`/`low level`高低电平是芯片硬件说法，具体情况请参考硬件文档说明；

## 相关说明

[C#版本的软件参考链接](https://github.com/AplexOS/Windows-Examples/tree/SBC-7116_SuperIOGPIO_Win7)
