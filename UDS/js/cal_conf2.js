
//Define calendar(s): addCalendar ("Unique Calendar Name", "Window title", "Form element's name", Form name")
addCalendar("Calendar1", "Select Date", "firstinput", "sampleform");
addCalendar("Calendar2", "Select Date", "secondinput", "sampleform");

// default settings for English
// Uncomment desired lines and modify its values
// setFont("verdana", 9);
 setWidth(90, 1, 15, 1);
// setColor("#cccccc", "#cccccc", "#ffffff", "#ffffff", "#333333", "#cccccc", "#333333");
// setFontColor("#333333", "#333333", "#333333", "#ffffff", "#333333");
// setFormat("yyyy/mm/dd");
// setSize(200, 200, -200, 16);

// setWeekDay(0);
// setMonthNames("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
// setDayNames("Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday");
// setLinkNames("[Close]", "[Clear]");




通过弹出窗口，点击选择日期，返回给文本框一个相应的日期，可自定制日期格式、窗口的颜色、尺寸，满足不同国家的语言，完全适合于不同的浏览器，包括IE4+/Win, IE5+/Mac, NN4x, N6+, Opera6+/Win and Konqueror3/Linux. 　















修改配置文件详看cal_conf2.js
1、添加一日期框
addCalendar("Calendar1", "Select Date", "firstinput", "sampleform");
-" Calendar1"- 你的日历唯一的名字。 可以是任何名字, 但是对于每个日历来说是唯一的。
-" Select Date"- 日历的弹出窗户的名称。 可以是任何名字。
-" firstinput"- 将会使用这一个日历形式的输入栏的名字。
-" sampleform"- 你的包含上述的输入栏的表单名字。
如果你的页面中只有唯一的一个表单，表单名字处可以为空""
所有项按默认设置，还可以写成
<form name="sampleform">
<input type="text" name="firstinput" size=20> <a href="javascript:showCal('Calendar1')">Select Date</a>
</form>
2、定义字型
setFont("verdana", 9);
3、定义日历宽度
setWidth(90, 1, 12, 1);
当一个日历出现的时候,它的标题将会显示当前的年月，可以能过箭头来选择前后的年份和月份

" setWidth(90,1,12,1)" 呼叫的第一个叁数是为日历显示定义的宽度。 你能调整它测试不同的字型和字型大小。

" setWidth(90,1,12,1)" 呼叫的第二个叁数是定义是否在一行或二行中显示年和月。 你能在这里使用 1 或 2 。 如果你使用二行, 年和月两边都会出现箭头，以方便单独调整。

" setWidth(90,1,12,1)" 呼叫的第三个叁数是定义日历显示的一天单元格的宽度。

" setWidth(90,1,12,1)" 呼叫的最后叁数是定义你如何显示每天。 通常你将会使用 1 或 3, 假如你选择 1 星期日将会显示成S,如果选择 3 将会显示成Sun。
4. 设置背景颜色
setColor("#cccccc", "#cccccc", "#ffffff", "#ffffff", "#333333", "#cccccc", "#333333");
5. 设置字体颜色
setFontColor("#333333", "#333333", "#333333", "#ffffff", "#333333");
6. 设置日期格式
setFormat("yyyy/mm/dd");
定义日期显示格式，你将用"yyyy","mm","dd"代表年、月、日，用"DAY"（SUN）或"Day"（Sun）代表星期几，用"MON"（JAN）或"Mon"（Jan）代表月份。
"/"是分隔符，你能使用任何符号（除了 "yyyy", "mm", "dd", "day" and "mon"）来做为分隔符，因此它的形式可以为"yyyymmdd", "Date: yyyy-mm(Mon)-dd", "mm dd, yyyy" 和 "Day. dd-Mon-yyyy is a good date", 等等。
7. 设置弹出窗口的大小尺寸
setSize(200, 200, -200, 16);
最初二个叁数,[200,200],定义弹出窗户的大小,你可能想要为不同的字型和字型大小调整他们。 最后二个叁数,[-200,16],为弹出窗户定义显示位置。 它是相对于点击弹出窗口的链接的位置而言。

在这个例子中，一个链接用来显示日历, 它会弹出200x200大小的窗口，位置显示在输入框的下面。 因此, 基于你按的链接在哪里,-200 是到窗口移到左边, 16 是窗户显示在日期领域下面。 你能为不同的表单来调整他们。
8.定义日期格式
setWeekDay(0);
设定到 0 为星期日, 否则设定到 1 为星期一来表示每周的每一天。
9. 以除英语外的另一种语言来表示
setMonthNames("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
setDayNames("Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday");
setLinkNames("[Close]", "[Clear]");
你可以用自己的语言替换这些名称

#一些有用的功能
1. checkDate(CalendarName)
返回0表示日期符合格式检测，返回1表示通过格式检测，返回2表示为空或没有通过格式检测
2. getCurrentDate()
返回以setFormat()格式定义的当前日期
3. compareDates(date1, date2)
比较两个日期，假如返回0，表示两个日期相等， -1 是 date1 是比 date2 早,  1 是 date1 是比 date2 迟的