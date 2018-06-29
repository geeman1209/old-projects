<?PHP
function start_page()
{
echo "<html>";
echo("<head>");
echo("<title>CEC-Computer Inventory</title>");
echo("<meta name=\"description\" content=\" \">");
echo("  <meta name=\"keywords\" content=\" \">");
echo "<style type=\"text/css\">";
echo "<!--
BODY {color:#003366; font-size: 14pt; font-family: arial; background-color: transparent;}

A:link {color:#FFFF00; font-weight: bold; text-decoration: none; font-size: 10pt; font-family:arial;}
A:visited {color:#FFFF00; font-weight: bold; text-decoration: none; font-size: 10pt; font-family:arial;}
//A:hover {color:#003366}

TH {font-family:arial; font-size:16;font-weight:bold; text-align:center; color:#003366;  }
.th1 {font-family:arial; font-size:16;font-weight:bold; text-align:center; color:#666699;  }
.tdheader {background-color:#003366;color:#FFFFFF; font-size:18; font-family:arial;font-weight:bold;}
.thheader {background-color:#003366;color:#FFFFFF; font-size:18; font-family:arial;font-weight:bold;}

td {color:#003366; font-size:16; font-family:arial;}
.td1 {background-color:#FFFF99;font-size:16; font-family:arial;}
.td2 {color:#CCCCCC; font-family:arial;font-size: 3mm;font-weight: bold;}
.td3 {text-align:center;background-color:#003366;font-size:16; font-family:arial;}
.td4 {line-height:3.5mm;font-size:14; font-family:arial;}  
.td8 {line-height:5mm;font-size:14; font-family:arial;} 
.td5 {line-height:3.5mm;font-size:12; font-family:arial;} 
.td6 {line-height:3.5mm;font-size:12; font-family:arial;font-weight:bold;}  
.td7 {line-height:6mm;font-size:16; font-family:arial;} 
.td9 {line-height:5mm;font-size:14; font-family:arial;color:#FFFF00} 
.title {color:red; font-size:16; font-family:arial;}

.fixedtablewidth {width :850; cell-spacing:2mm; border:.5mm outset; border-color:#003366;}
.fixedtablewidth1 {width : 850; cell-spacing:2mm; background : #FFFFFF; border : .5mm outset;border-color:#003366;}
.fixedtablewidth1B {width : 850; cell-spacing:2mm; background : #FFFFFF; border : .5mm outset;border-color:#003366;} 
.fixedtablewidth2 {width : 850; cell-spacing:2mm; background : #FFFFFF; border-color=#003366;}
.fixedtablewidth4 {width : 850; cell-spacing:2mm; background : #F2F2F2; border : .5mm outset;border-color:#003366;}     
.fixedtablewidth5 {width : 850; cell-spacing:2mm; background : #FFFF99; border : .5mm outset;border-color:#003366;}
.fixedtablewidth6 {width : 850; cell-spacing:0mm; background : #CCCCCC; border : .5mm outset;border-color:#336699;}
.fixedtablewidth7 {width : 600; cell-spacing:2mm; background : #FFFFFF; border : .5mm outset;border-color:#003366;}
.fixedtablewidth8 {width : 850; cell-spacing:2mm; background : #CCCCFF; border : .5mm outset;border-color:#003366;}    
.fixedtablewidthtabs {width : 850; cell-spacing:2mm; background : #F2F2F2;border : 1mm outset;border-color:#336699;} 
.autotablewidth2 {width : auto;cell-spacing:2mm;background : red;border : .5mm outset;border-color:#003366;}
.autotablewidth3 {width : auto;cell-spacing:2mm;background : #003366;outset;border-color:#003366;}   

                                             
.headertable {width : 850;cell-spacing:2mm;background : #003366;}


.textable {  font-family: arial, serif;
                font-size: small;
                background-color: #CCCCCC;
                padding-top: 20px;
                padding-right: 10px;
                padding-bottom: 20px;
                padding-left: 10px;}

.FormatErrorMessage {font-weight:bold; color:#FF0000; font-size:11; font-family:arial;}
.FormatInfoMessage {font-weight:bold; color:#005858; font-size:14; font-family:arial;} 
.FormatSuccessMessage {font-weight:bold; color:#800000; font-size:18; font-family:arial;}
.FormatFailMessage {font-weight:bold; color:#FF0000; font-size:11; font-family:arial;}
.FormatInstruction {color:#000080; font-size:14; font-family:arial;}

.input1 {background-color: #003366; color:#FFFF00; font-weight: bold; font-size: 12px;}      
.input2 {color:#003366; font-size: 3mm;font-weight: bold;} 

.input3 {color:#003366; font-size: 3mm;font-weight: bold; }  
.input4 {color:#003366; font-size: 3mm;font-weight: bold; } 
.input5 {color:#003366; font-size: 3mm;font-weight: bold; padding:0;}   
.input6 {color:#003366; font-size: 2.5mm;font-weight: bold;} 
textarea1 {font-size: 11px; font-family:arial;}
select1 {background-color: #cccccc; color: #003366; font-weight: bold; font-size: 11px;}

.inputwarning {background-color: #CCCCCC; color:#FF0000; font-weight: bold; font-size: 12px; SIZE:25; MAXLENGTH:50}

  -->
  </style>";
 echo("</head>");
}


function FetchSingleColumnDataFromDatabase($table,$ModuleName,$CaseName,$SectionName,$DataElement)
{
     //if (mysqli_connect_errno()) echo "Failed to connect to MySQL: " . mysqli_connect_error(); // Check connection
   
	$ConnectionID=mysqli_connect('10.91.10.151:3309','csu','[2018csu@Jan]','clinicalskills');
    //if (mysqli_connect_errno()) echo "Failed to connect to database"; // Check connection
	
   
	$SQL = "SELECT $DataElement FROM $table where ModuleName='$ModuleName' AND CaseName='$CaseName' AND SectionName='$SectionName' order by QuestionID ASC";
	$result=mysqli_query($ConnectionID,$SQL);
    while ($row=mysqli_fetch_array($result,MYSQLI_NUM)) $DataArray[] =$row[0];
    mysqli_free_result($result); // Free result set
	mysqli_close($ConnectionID);
	return $DataArray;

}

function CreateTextbox($Label,$Name,$Value,$Length,$Error)
{
	if ($Error) echo "<tr><td width=75 ><font size=\"-1\">$Label&nbsp;</td><td><input type=\"text\" name=$Name size=$Length maxlength=$Length value=$Value><font class=FormatErrorMessage> **Required</td></tr>";
	else echo "<tr><td width=75 ><font size=\"-1\">$Label&nbsp;</td><td><input type=\"text\" name=$Name size=$Length maxlength=$Length value='$Value'></td></tr>";
}



function CreateDropDownMenu($label,$name,$choice,$MyArray,$width,$shading,$error)
{
global $PHP_SELF;
	if ($shading%2)
	echo "<tr bgcolor=\"#F2F2F2\">";
	else "<tr>";
    echo "<td width=$width><font size=\"-1\">$label</td>";
    echo "<td><select name=$name>";
    foreach($MyArray as $value)
    {
            if ($value == $choice)
                echo("<option  selected value='$value'>$value</option>");
            else
                echo("<option  value='$value'>$value</option>");
    }
    if ($error) echo "</select><font class=FormatErrorMessage> **</font></td>";
    else echo "</select></td>";
	//echo "<td width=50>&nbsp;</td></tr>";
    echo "</tr>";
}

function PrintPageHeader($PageHeaderLabel,$FirstName,$LastName,$StudentID)
{

	echo "<table widht=850>";
	echo "<tr width=850 boder=2><td align=\"center\" valign=\"middle\" ><strong><font size=\"+2\">$PageHeaderLabel</font></strong></td></tr>";
	echo "<tr><td>&nbsp;</td></tr>";
	echo "<tr><td ><font size=\"-1\">First Name:&nbsp;$FirstName</td></tr>";
	echo "<tr><td ><font size=\"-1\">Last Name:&nbsp;$LastName</td></tr>";
	echo "<tr><td ><font size=\"-1\">Student ID:&nbsp;$StudentID</td></tr>";
	echo "</table>";
}
function PrintChecklistArrayAnswers($ChecklistArrayLabel,$ChecklistArray,$ChecklistArray_StudentAnswer,$ChecklistArray_ConcensusAnswer)
{
	echo "</table>";echo "<table widht=850>";
	echo "<tr><td colspan=3 align=center><strong>&nbsp;</strong></td></tr>";
	echo "<tr bgcolor=\"#FF7F27\" ><td colspan=3 align=center><strong>$ChecklistArrayLabel</strong></td></tr>";
	echo "<tr bgcolor=\"#F2F2F2\" ><td align=\"center\" valign=\"middle\"><strong><font size=\"2\">Question</font></strong></td><td align=\"center\" valign=\"middle\"><strong><font size=\"2\">Your Answer</font></strong></td><td align=\"center\" valign=\"middle\"><strong><font size=\"2\">Concensus Answer</font></strong></td></tr>";

	for ($j = 0; $j < count($ChecklistArray); $j++)
	{
		if( $ChecklistArray_StudentAnswer[$j] ==0 ) $ChecklistArray_StudentAnswer[$j] = '--' ;
		else $ChecklistArray_StudentAnswer[$j] = 'Yes';
		
		if ($j%2) { echo "<tr bgcolor=\"#F2F2F2\">";}
		else { echo "<tr>";}
		echo "<td valign=\"middle\">&nbsp;<font size=\"-1\">$ChecklistArray[$j]&nbsp;</td><td align=\"center\" valign=\"middle\">&nbsp;<font size=\"-1\">$ChecklistArray_StudentAnswer[$j]&nbsp;</td><td align=\"center\" valign=\"middle\">&nbsp;<font size=\"-1\">$ChecklistArray_ConcensusAnswer[$j]&nbsp;</td></tr>";
		
		echo "</tr>";
	}
	 echo "</table>";
}

function PrintDropdownArrayAnswers($DropdownArrayLabel,$DropdownArray,$DropdownArray_StudentAnswer,$DropdownArray_ConcensusAnswer)
{
	echo "<table widht=850>";
	echo "<tr><td colspan=3 align=center><strong>&nbsp;</strong></td></tr>";
	echo "<tr bgcolor=\"#FF7F27\" ><td colspan=3 align=center><strong>$DropdownArrayLabel</strong></td></tr>";
	echo "<tr bgcolor=\"#F2F2F2\" ><td align=\"center\" valign=\"middle\"><strong><font size=\"2\">Question</font></strong></td><td align=\"center\" valign=\"middle\"><strong><font size=\"2\">Your Answer</font></strong></td><td align=\"center\" valign=\"middle\"><strong><font size=\"2\">Concensus Answer</font></strong></td></tr>";
	
	for ($i = 0; $i < count($DropdownArray); $i++) 
	{
		
	 	if ($i % 2) { echo "<tr bgcolor=\"#F2F2F2\">";}
		else { echo "<tr>";}
		echo "<td valign=\"middle\">&nbsp;<font size=\"-1\">$DropdownArray[$i]&nbsp;</td><td align=\"center\" valign=\"middle\">&nbsp;<font size=\"-1\">$DropdownArray_StudentAnswer[$i]&nbsp;</td><td align=\"center\" valign=\"middle\">&nbsp;<font size=\"-1\">$DropdownArray_ConcensusAnswer[$i]&nbsp;</td>";
		echo "</tr>";	
	}
}


function SaveAnswers($FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$SectionName,$Question,$StudentAnswer,$ConcensusAnswer)
{
        
	$ConnectionID=mysqli_connect('10.91.10.151:3309','csu','[2018csu@Jan]','clinicalskills');
	if (mysqli_connect_errno()) echo "Failed to connect to MySQL: " . mysqli_connect_error(); // Check connection
	
	// =================== START - CLEAN DATA =============================================================================
	//Escapes special characters in the unescaped_string, taking into account the current 
	//character set of the connection so that it is safe to place it in a mysql_query(). If binary data is to be inserted, this function must be used. 
	
	//$FirstName = mysqli_real_escape_string($ConnectionID,$FirstName);
	//$LastName = mysqli_real_escape_string($ConnectionID,$LastName);
	//$StudentID = mysqli_real_escape_string($ConnectionID,$StudentID);
	$ModuleName = mysqli_real_escape_string($ConnectionID,$ModuleName);
	$CaseName = mysqli_real_escape_string($ConnectionID,$CaseName);
	$SectionName = mysqli_real_escape_string($ConnectionID,$SectionName);
	$Question = mysqli_real_escape_string($ConnectionID,$Question);
	$StudentAnswerdentID = mysqli_real_escape_string($ConnectionID,$StudentAnswer);	
	$ConcensusAnswer = mysqli_real_escape_string($ConnectionID,$ConcensusAnswer);	
// =================== END - CLEAN DATA =============================================================================
	

	

	$SQL="insert into StudentAnswers Values(NULL, CURRENT_TIMESTAMP,'$FirstName','$LastName','$StudentID','$ModuleName','$CaseName','$SectionName','$Question','$StudentAnswer','$ConcensusAnswer')"; 
	//echo "SQL = $SQL<br>";
	$result=mysqli_query($ConnectionID,$SQL);
    if($result)  $Success =1;  else  $Success =0;                      
	mysqli_close($ConnectionID);
    Return  $Success;
      
}  
?>