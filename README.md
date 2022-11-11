# LineNotifierCmd

## Usage
``` shell
LineNotifierCmd "[ENTER_YOUR_LINE_TOKEN]" "[YOUR_MESSAGE]"
```

## Applying in MultiCharts (Pro Only)

Create a function called LineNotify (which is only notifying Line when LastBarOnChart is true)
```
DefineDLLFunc:"shell32.dll", Long, "ShellExecuteA", Long, lpstr, lpstr, lpstr, lpstr, Long;
inputs:  lineNotifierPath(string),lineToken(string), lineMsg(string);

If LastBarOnChart And lineToken <> "" Then Begin
	ShellExecuteA(0, "open", lineNotifierPath, DoubleQuote  + lineToken + DoubleQuote + " " + DoubleQuote + lineMsg + DoubleQuote , "", 5);	
End;
```

Copied LineNotifierCmd.exe to a path (assuming "C:\LineNotifierCmd\")

In your script, call LineNotify function
```
Inputs: 
	lineToken("[ENTER_YOUR_LINE_TOKEN]"),
	cmdPath("C:\LineNotifierCmd\");

LineNotify(cmdPath, lineToken, "Test: send message to Line");
```
