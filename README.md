# NoxAdbDumper
搞這個程式只是因為很多APP都會針對GameGuardian，所以用GameGuardian Dump內存太常失敗了，用IDA之類的再另外寫腳本也不太方便，所以整了一個專門從夜神模擬器Dump內存的程式

如果有發現Bug，非常歡迎Fork走後改完再發Pull requests成為貢獻者加入這個專案

至於報Issue的話，大概率會咕咕咕

The reason for write this program is that there are many apps detect the GameGuardian, so it often fails to Dump memory using GameGuardian, and it's not convenient to write scripts using IDA or something like that, so I created a program that use ADB with WPF GUI interface to dumps memory from the NoxPlayer.

If bugs are found, you are welcome to Fork and then send Pull Requests to be a contributors of the project

## 介面 / GUI
![image](https://user-images.githubusercontent.com/33422418/136706147-c907fb2c-7047-4856-8864-e12d6bbc708c.png)

## 基本操作流程 / Basic operation process
1. Action → Connect Nox ADB to devices → <點擊選擇Device> → Select
2. Action → Refresh Process List

3. 現在你可以看到Nox上的進程了，如果有要針對某個APP的話，請直接用最下方的Search欄位來快速搜尋<br>
   Now you can see the processes on Nox. If you want to specific apps, use the Search bar at the bottom to quickly Search for them.
   ![image](https://user-images.githubusercontent.com/33422418/136706280-a495a491-4cdd-4f4b-bbf7-1569e615032c.png)

4. 一個APP的進程可能會有多個子進程，這時可以點擊來選擇進程後用 Get Memory Map of Process然後點進Memory Map，看是不是你想要的進程<br>
   An APP Process may have multiple child processes. Now you can click to select the Process and use Get Memory Map of Process. Then click on the Memory Map tab to see if the Process is the one you want

   舉例來說: 你要搞Assembly-Csharp.dll，那你就要找有libmono.so的進程<br>
   For example: if you want Assembly-Csharp.dll, you need to find a process that has libmono.so

5. 找到之後 Kill → Kill -19 Stop Select Process 停掉進程，目的是要讓他的Ptrace跟其他的偵測機制都停掉才能好好完成的Dump<br>
   After finding, Kill → Kill -19 Stop Select Process to stop Ptrace and all other detection mechanisms
6. Action → Dump All Memory of Processs → <選擇要輸出到哪 / Select where to output>
   然後你應該就能在那個資料夾找到Dump後的內存了名稱會叫dump.bin，想要什麼東西就拿Hex Editor跟寫個程式自己找吧<br>
   You should be able to find the memory after Dump in the folder named dump.bin. You can write a program or use Hex Editor to find anything you want by yourself

## 想加的東西 / Want ToDo
1. 有可能會遇到多個互相ptrace的情況，但做介面的時候怕用的人會在不該多選的時候多選，所以用了ListBox而非ListView，希望能改ListView並用個checkbox或啥的平時鎖掉多選功能就好<br>
   There may be multiple ptrace, but when I make the interface, I afraid of people using it will be in the shouldn't multiple selection of time to multiple select, so use ListBox instead of ListView, hope can change to the ListView and use a checkbox to on off the multiple selection
2. 可以嘗試整合這個東西 [LibDumper](https://github.com/BryanGIG/LibDumper) 進來方便Dump so跟global-metadata<br>
   Can try to integrate this program [LibDumper](https://github.com/BryanGIG/LibDumper) to Dump so and global-metadata
