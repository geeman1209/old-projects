<?php
$query = $_POST['query'];
$value = $_POST['value'];
$label = $_POST['label'];

if(empty($query))
{
    echo "You have a empty search value";
    exit;
}
else{

echo "You have enter:"." ".$query;
echo "<br>";
echo "You have selected this:"."".$value;
echo "<br>";
echo "You have added this:"."".$label;
}

?>
