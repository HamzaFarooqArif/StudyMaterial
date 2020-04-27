<!DOCTYPE html>
<html>
<style>
    table,th,td {
        border : 1px solid black;
        border-collapse: collapse;
    }
    th,td {
        padding: 5px;
    }
</style>
<body>

<h1>The XMLHttpRequest Object</h1>

<form action="">
    <select id ="ddselect" name="customers">
        <option value="">Select a customer:</option>
        <option value="1">Hamza</option>
        <option value="2">Farooq</option>
        <option value="3">Arif</option>
    </select>
    <br>
    <input id = "txtselect" type="text" name="sender" placeholder = "Your GoodName">
    <br>
    <button type="button" OnClick="showCustomer(document.getElementById('ddselect').value, document.getElementById('txtselect').value)">Send</button>
</form>
<br>
<div id="txtHint">Customer info will be listed here...</div>

<script>
    function showCustomer(str, senderName) {
        var xhttp;
        if (str == "") {
            document.getElementById("txtHint").innerHTML = "Err: Select a valid Customer";
            return;
        }
        if (senderName == "") {
            document.getElementById("txtHint").innerHTML = "Err: Enter a valid Sender Name";
            return;
        }
        xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function() {
            if (this.readyState == 4 && this.status == 200) {
                document.getElementById("txtHint").innerHTML = this.responseText;
            }
        };
        xhttp.open("GET", "getcustomer.php?customerId="+str+"&senderName="+senderName, true);
        xhttp.send();
    }
</script>

</body>
</html>