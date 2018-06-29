<?php

 function makeTextInputField($label,$name) {
        $text = ucfirst($label);
        echo "
            <label for='{$label}'>{$text}</label>
            <input type='text' name='{$name}' />
        ";
    }

function makeFormSubmit($myaction,$label,$name,$MyArray) {
        $text = ucfirst($label);
        echo "
            <form action='$myaction' method=POST>
            <label for='{$label}'>{$text}</label>
            <input type='text' name='{$name}' /> ";
            echo "<select name='value'>";// Open your drop down box

		    foreach ($MyArray as $value) 
		    {   		  
		   	 echo ('<option value="'.strip_tags($value).'" input name=value">'.$value.'</option>');
			}
		  	 
		  	 echo "</select>";

		  	 echo "
            <input type='submit' value='Search' />

          ";
    }

    function makeAddForm()
    {
    	$nameArray = array('fname', 'lname', 'SerialNumber', 'ComputerName', 'School', 'GraduatingYear', 'LaptopModel');
    	$label = $nameArray;

		for( $i = 0; $i < count($nameArray); $i++)
    	{
    			echo "<br>";
    			makeTextInputfield($label[$i], $nameArray[$i]);
    			echo "<br>";	 		
    	}

    	echo "<input type='submit' value='ADD' />";
    	
    }


?>
