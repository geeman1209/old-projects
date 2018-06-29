<?php
include("c:/inetpub/MyIncludes/functions.inc");


//===========================	START - DEFINE GLOBAL VARIABLES =======================================================================
start_page();
$ScriptName = $_SERVER['SCRIPT_NAME']; 
$PrintedPageHeader = strtoupper('COMPARISON OF SCORES FOR Adult History Scoring Form'); //Value displayed on the resuilts page
$ModuleLabel = strtoupper('Adult History Scoring Form');//Value displayed in titles
$ModuleName = 'History Module';////Value stored in MySQL Database. Used to fetch and store data
$CaseLabel = strtoupper('Adult History Scoring Form');
$CaseName = 'Adult History'; //Value stored in MySQL Database. Used to fetch and store data
$Section1Label = 'Chief Complaint'; //Value displayed in titles
$Section1Name = 'Chief Complaint'; //Value stored in MySQL Database. Used to fetch and store data
$Section2Label = 'Past Medical History'; //Value displayed in titles
$Section2Name = 'Past Medical History'; //Value stored in MySQL Database. Used to fetch and store data
$Section3Label = 'Social History'; //Value displayed in titles
$Section3Name = 'Social History'; //Value stored in MySQL Database. Used to fetch and store data
$Section4Label = 'Family History'; //Value displayed in titles
$Section4Name = 'Family History'; //Value stored in MySQL Database. Used to fetch and store data
$Section5Label = 'MIRS'; //Value displayed in titles
$Section5Name = 'MIRS'; //Value stored in MySQL Database. Used to fetch and store data
$DropdownArray = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section1Name,'QuestionText');
$DropdownArray_ConcensusAnswer = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section1Name,'ConsensusAnswer');
$Dropdown2Array = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section2Name,'QuestionText');
$Dropdown2Array_ConcensusAnswer = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section2Name,'ConsensusAnswer');
$Dropdown3Array = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section3Name,'QuestionText');
$Dropdown3Array_ConcensusAnswer = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section3Name,'ConsensusAnswer');
$Dropdown4Array = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section4Name,'QuestionText');
$Dropdown4Array_ConcensusAnswer = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section4Name,'ConsensusAnswer');
$Dropdown5Array = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section5Name,'QuestionText');
$Dropdown5Array_ConcensusAnswer = FetchSingleColumnDataFromDatabase('Questions',$ModuleName,$CaseName,$Section5Name,'ConsensusAnswer');

//===========================	START - DISPLAY INITIAL FORM =======================================================================
//=========***************************************************************************************************************==========
if (!isset($_POST['InitialSubmission'])) // if true, then show questions for student to answer; do not check for errors yet
{     
	echo "<form method=POST ACTION=$ScriptName>"; 

	//=======================	Start Display Student Info ===============================
	echo "<table widht=850>";
	echo "<tr width=850 border=2><td align=\"center\" valign=\"middle\" colspan=2><strong><font size=\"+2\">$CaseLabel</font></strong></td></tr>";
	echo "<tr><td colspan=2>&nbsp;</td></tr>";
	echo "</table>";

	echo "<table>";	
	CreateTextbox('First Name:','FirstName','',30,0);
	CreateTextbox('Last Name:','LastName','',30,0);
	CreateTextbox('Student ID:','StudentID','',30,0);
	echo "</table>";
	
	//=======================	End Display Student Info ===============================

	//=======================	Start Display Dropdown ==================================
	echo "<table widht=850>";
	echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
	echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section1Label</strong></td></tr>";
	echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";

	for ($j = 0; $j < count($DropdownArray); $j++)
	{
		$name = 'DropdownArray_StudentAnswer'.'['.$j.']';
		CreateDropDownMenu($DropdownArray[$j],$name,'select answer',array('select answer','Yes','No'),400,$j,0);
	}
	//=======================	End Display Dropdown ==================================
	
	//=======================	Start Display Dropdown 2==================================
	echo "<table widht=850>";
	echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
	echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section2Label</strong></td></tr>";
	echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";

	for ($j = 0; $j < count($Dropdown2Array); $j++)
	{
		$name = 'Dropdown2Array_StudentAnswer'.'['.$j.']';
		CreateDropDownMenu($Dropdown2Array[$j],$name,'select answer',array('select answer','Yes','No'),400,$j,0);
	}
	//=======================	End Display Dropdown 2 ==================================
	
	//=======================	Start Display Dropdown 3==================================
	echo "<table widht=850>";
	echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
	echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section3Label</strong></td></tr>";
	echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";

	for ($j = 0; $j < count($Dropdown3Array); $j++)
	{
		$name = 'Dropdown3Array_StudentAnswer'.'['.$j.']';
		CreateDropDownMenu($Dropdown3Array[$j],$name,'select answer',array('select answer','Yes','No'),400,$j,0);
	}
	//=======================	End Display Dropdown 3 ==================================	
	
	//=======================	Start Display Dropdown 4==================================
	echo "<table widht=850>";
	echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
	echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section4Label</strong></td></tr>";
	echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";

	for ($j = 0; $j < count($Dropdown4Array); $j++)
	{
		$name = 'Dropdown4Array_StudentAnswer'.'['.$j.']';
		CreateDropDownMenu($Dropdown4Array[$j],$name,'select answer',array('select answer','Yes','No'),400,$j,0);
	}
	//=======================	End Display Dropdown 4 ==================================	
	
	//=======================	Start Display Dropdown 5 ==================================
	echo "<table widht=850>";
	echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
	echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section5Label</strong></td></tr>";
	echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";

	for ($j = 0; $j < count($Dropdown5Array); $j++)
	{
		$name = 'Dropdown5Array_StudentAnswer'.'['.$j.']';
		CreateDropDownMenu($Dropdown5Array[$j],$name,'select answer',array('select answer',1,2,3,4,5),400,$j,0);
	}
	//=======================	End Display Dropdown 5 ==================================

	echo "<input type='hidden' name='InitialSubmission' value='1'>";
	echo "<tr><td  ><input type=submit value='&nbsp;Submit&nbsp;'></td></tr>";
	echo "</table>"; 
	echo "</form>"; 
}
//=========***************************************************************************************************************==========
//===========================	END - DISPLAY INITIAL FORM =========================================================================

//===========================	START - CHECK ANSWERS FOR ERRORS AND RE-DISPLAY OR PRINT/SAVE ANSWEWRS==============================
//=========***************************************************************************************************************==========
else //Form is submitted; check for answers and errors
{
	$StudentID = $_POST['StudentID'];
	$FirstName = $_POST['FirstName'];
	$LastName = $_POST['LastName'];
	$DropdownArray_StudentAnswer=$_POST['DropdownArray_StudentAnswer']; 
	$Dropdown2Array_StudentAnswer=$_POST['Dropdown2Array_StudentAnswer']; 
	$Dropdown3Array_StudentAnswer=$_POST['Dropdown3Array_StudentAnswer']; 
	$Dropdown4Array_StudentAnswer=$_POST['Dropdown4Array_StudentAnswer']; 
	$Dropdown5Array_StudentAnswer=$_POST['Dropdown5Array_StudentAnswer']; 
	
	if (empty($StudentID)) $StudentIDError = 1; else  $StudentIDError=0;
	if (empty($FirstName)) $FirstNameError = 1; else  $FirstNameError=0;
	if (empty($LastName)) $LastNameError = 1; else  $LastNameError=0;
	
	$DropdownArray_Errors=0;	
	for ($i = 0; $i < count($DropdownArray_StudentAnswer); $i++) if ($DropdownArray_StudentAnswer[$i] =='select answer') $DropdownArray_Errors++;
	
	$Dropdown2Array_Errors=0;	
	for ($i = 0; $i < count($Dropdown2Array_StudentAnswer); $i++) if ($Dropdown2Array_StudentAnswer[$i] =='select answer') $Dropdown2Array_Errors++;

	$Dropdown3Array_Errors=0;	
	for ($i = 0; $i < count($Dropdown3Array_StudentAnswer); $i++) if ($Dropdown3Array_StudentAnswer[$i] =='select answer') $Dropdown3Array_Errors++;

	$Dropdown4Array_Errors=0;	
	for ($i = 0; $i < count($Dropdown4Array_StudentAnswer); $i++) if ($Dropdown4Array_StudentAnswer[$i] =='select answer') $Dropdown4Array_Errors++;
	
	$Dropdown5Array_Errors=0;	
	for ($i = 0; $i < count($Dropdown5Array_StudentAnswer); $i++) if ($Dropdown5Array_StudentAnswer[$i] =='select answer') $Dropdown5Array_Errors++;
	
	$Total_Errors= $StudentIDError + $FirstNameError + $LastNameError + $DropdownArray_Errors + $Dropdown2Array_Errors + $Dropdown3Array_Errors + $Dropdown4Array_Errors + $Dropdown5Array_Errors;

	if ($Total_Errors)
	{
		//=======================	Start Re-display Student Info ===============================
		echo "<form method=POST ACTION=$ScriptName>"; 

		echo "<table widht=850>";
		echo "<tr width=850 border=2><td align=\"center\" valign=\"middle\" colspan=2><strong><font size=\"+2\">$CaseLabel</font></strong></td></tr>";
		echo "<tr><td colspan=2>&nbsp;</td></tr>";
		echo "</table>";

		echo "<table>";
		CreateTextbox('First Name:','FirstName',$FirstName,30,$FirstNameError);
		CreateTextbox('Last Name:','LastName',$LastName,30,$LastNameError);
		CreateTextbox('Student ID:','StudentID',$StudentID,30,$StudentIDError);
		echo "</table>";
		
		//=======================	End Re-display Student Info ===============================

		//=======================	Start Re-display Dropdown ==================================
		echo "<table widht=850>";
		echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
		echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section1Label</strong></td></tr>";
		if ($DropdownArray_Errors) echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=right><font class=FormatErrorMessage>** Required</font></td></tr>";
		else echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";
	
		for ($j = 0; $j < count($DropdownArray); $j++)
		{
			if ($DropdownArray_StudentAnswer[$j] =='select answer') $error=1;
			else $error=0;
			$name = 'DropdownArray_StudentAnswer'.'['.$j.']';
			CreateDropDownMenu($DropdownArray[$j],$name,$DropdownArray_StudentAnswer[$j],array('select answer','Yes','No'),400,$j,$error);
		}
		//=======================	End Re-display Dropdown ================================== 

		//=======================	Start Re-display Dropdown 2 ==================================
		echo "<table widht=850>";
		echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
		echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section2Label</strong></td></tr>";
		if ($Dropdown2Array_Errors) echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=right><font class=FormatErrorMessage>** Required</font></td></tr>";
		else echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";
	
		for ($j = 0; $j < count($Dropdown2Array); $j++)
		{
			if ($Dropdown2Array_StudentAnswer[$j] =='select answer') $error=1;
			else $error=0;
			$name = 'Dropdown2Array_StudentAnswer'.'['.$j.']';
			CreateDropDownMenu($Dropdown2Array[$j],$name,$Dropdown2Array_StudentAnswer[$j],array('select answer','Yes','No'),400,$j,$error);
		}
		//=======================	End Re-display Dropdown 2 ================================== 

		//=======================	Start Re-display Dropdown 3 ==================================
		echo "<table widht=850>";
		echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
		echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section3Label</strong></td></tr>";
		if ($Dropdown3Array_Errors) echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=right><font class=FormatErrorMessage>** Required</font></td></tr>";
		else echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";
	
		for ($j = 0; $j < count($Dropdown3Array); $j++)
		{
			if ($Dropdown3Array_StudentAnswer[$j] =='select answer') $error=1;
			else $error=0;
			$name = 'Dropdown3Array_StudentAnswer'.'['.$j.']';
			CreateDropDownMenu($Dropdown3Array[$j],$name,$Dropdown3Array_StudentAnswer[$j],array('select answer','Yes','No'),400,$j,$error);
		}
		//=======================	End Re-display Dropdown 3 ================================== 
		

		//=======================	Start Re-display Dropdown 4 ==================================
		echo "<table widht=850>";
		echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
		echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section4Label</strong></td></tr>";
		if ($Dropdown4Array_Errors) echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=right><font class=FormatErrorMessage>** Required</font></td></tr>";
		else echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";
	
		for ($j = 0; $j < count($Dropdown4Array); $j++)
		{
			if ($Dropdown4Array_StudentAnswer[$j] =='select answer') $error=1;
			else $error=0;
			$name = 'Dropdown4Array_StudentAnswer'.'['.$j.']';
			CreateDropDownMenu($Dropdown4Array[$j],$name,$Dropdown4Array_StudentAnswer[$j],array('select answer','Yes','No'),400,$j,$error);
		}
		//=======================	End Re-display Dropdown 4 ==================================
		
		//=======================	Start Re-display Dropdown 5 ==================================
		echo "<table widht=850>";
		echo "<tr><td colspan=2 align=center><strong>&nbsp;</strong></td></tr>";
		echo "<tr bgcolor=\"#FF7F27\" ><td colspan=2 align=center><strong>$Section5Label</strong></td></tr>";
		if ($Dropdown5Array_Errors) echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=right><font class=FormatErrorMessage>** Required</font></td></tr>";
		else echo "<tr bgcolor=\"#F2F2F2\" ><td colspan=2 align=center>&nbsp;</td></tr>";
	
		for ($j = 0; $j < count($Dropdown5Array); $j++)
		{
			if ($Dropdown5Array_StudentAnswer[$j] =='select answer') $error=1;
			else $error=0;
			$name = 'Dropdown5Array_StudentAnswer'.'['.$j.']';
			CreateDropDownMenu($Dropdown5Array[$j],$name,$Dropdown5Array_StudentAnswer[$j],array('select answer',1,2,3,4,5),400,$j,$error);
		}
		//=======================	End Re-display Dropdown 5================================== 
		
		echo "<input type='hidden' name='InitialSubmission' value='0'>";
		echo "<tr><td  ><input type=submit value='&nbsp;Submit&nbsp;'></td></tr>";
		echo "</table>"; 
		echo "</form>"; 
	}
	else //no errors - print & save
	{
		PrintPageHeader($PrintedPageHeader,$FirstName,$LastName,$StudentID);
		PrintDropdownArrayAnswers($Section1Label,$DropdownArray,$DropdownArray_StudentAnswer,$DropdownArray_ConcensusAnswer);
		PrintDropdownArrayAnswers($Section2Label,$Dropdown2Array,$Dropdown2Array_StudentAnswer,$Dropdown2Array_ConcensusAnswer);
		PrintDropdownArrayAnswers($Section3Label,$Dropdown3Array,$Dropdown3Array_StudentAnswer,$Dropdown3Array_ConcensusAnswer);
		PrintDropdownArrayAnswers($Section4Label,$Dropdown4Array,$Dropdown4Array_StudentAnswer,$Dropdown4Array_ConcensusAnswer);
		PrintDropdownArrayAnswers($Section5Label,$Dropdown5Array,$Dropdown5Array_StudentAnswer,$Dropdown5Array_ConcensusAnswer);
						
		//Save Dropdown Answers to Database
		for ($j = 0; $j < count($DropdownArray); $j++)
		{
			$SaveOutcome = SaveAnswers($FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section1Name,$DropdownArray[$j],$DropdownArray_StudentAnswer[$j],$DropdownArray_ConcensusAnswer[$j]);
			if (!$SaveOutcome)echo "Failed to Save: $FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section1Name,$DropdownArray[$j],$DropdownArray_StudentAnswer[$j],$DropdownArray_ConcensusAnswer[$j]<br>";
		}	
		
		//Save Dropdown 2 Answers to Database
		for ($j = 0; $j < count($Dropdown2Array); $j++)
		{
			$SaveOutcome = SaveAnswers($FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section2Name,$Dropdown2Array[$j],$Dropdown2Array_StudentAnswer[$j],$Dropdown2Array_ConcensusAnswer[$j]);
			if (!$SaveOutcome)echo "Failed to Save: $FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section2Name,$Dropdown2Array[$j],$Dropdown2Array_StudentAnswer[$j],$Dropdown2Array_ConcensusAnswer[$j]<br>";
		}	
		
		//Save Dropdown 3 Answers to Database
		for ($j = 0; $j < count($Dropdown3Array); $j++)
		{
			$SaveOutcome = SaveAnswers($FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section3Name,$Dropdown3Array[$j],$Dropdown3Array_StudentAnswer[$j],$Dropdown3Array_ConcensusAnswer[$j]);
			if (!$SaveOutcome)echo "Failed to Save: $FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section3Name,$Dropdown3Array[$j],$Dropdown3Array_StudentAnswer[$j],$Dropdown3Array_ConcensusAnswer[$j]<br>";
		}	
		
		//Save Dropdown 4 Answers to Database
		for ($j = 0; $j < count($Dropdown4Array); $j++)
		{
			$SaveOutcome = SaveAnswers($FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section4Name,$Dropdown4Array[$j],$Dropdown4Array_StudentAnswer[$j],$Dropdown4Array_ConcensusAnswer[$j]);
			if (!$SaveOutcome)echo "Failed to Save: $FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section4Name,$Dropdown4Array[$j],$Dropdown4Array_StudentAnswer[$j],$Dropdown4Array_ConcensusAnswer[$j]<br>";
		}	
		
		//Save Dropdown 5 Answers to Database
		for ($j = 0; $j < count($Dropdown5Array); $j++)
		{
			$SaveOutcome = SaveAnswers($FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section5Name,$Dropdown5Array[$j],$Dropdown5Array_StudentAnswer[$j],$Dropdown5Array_ConcensusAnswer[$j]);
			if (!$SaveOutcome)echo "Failed to Save: $FirstName,$LastName,$StudentID,$ModuleName,$CaseName,$Section5Name,$Dropdown5Array[$j],$Dropdown5Array_StudentAnswer[$j],$Dropdown5Array_ConcensusAnswer[$j]<br>";
		}	
	}
}
//===========================	END - CHECK ANSWERS FOR ERRORS AND RE-DISPLAY OR PRINT/SAVE ANSWEWRS==============================
//=========***************************************************************************************************************==========




?>