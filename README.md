# 项目介绍
·本项目用于Oracle在多数据库中查找指定的表

·本项目为wpf程序

# 使用说明
·在Config文件配置数据库信息(配置一个高权限的库即可)

·目前理论上支持的数据库有：Oracle、 Sql Server、 SqLite、 Access（未在Oracle外的数据库中进行过测试）

·选择“数据表名称”时，输入表名称，显示存在该表的数据库名称

·选择“SQL语句”时，输入SQL语句，显示可以执行该语句的数据库名称

·未勾选“允许结果为空”时，将只输出可以执行并且结果不为空的数据库名称
  例如通过“数据表名称”查找时，将只输出存在表并存在数据的数据库名称

·因为程序使用WPF编写，最低.net版本只能为.net3.0，现程序所需.net版本为.net4.5.2

·核心代码“XYZZ.Library”已在github上开源，对应地址：
  https://github.com/MadeByXy/XYZZTools
