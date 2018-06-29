<?PHP
function ConnectToDatabases()
{
	mysqli_connect('localhost','root','June2018!','mastercomputerlist');
	if (mysqli_connect_errno())	echo "Failed to connect to MySQL: " . mysqli_connect_error();
	else echo "connect";
}

?>