 
<link rel="stylesheet" href=" <?php echo base_url()?>assets/css/w3.css" type="text/css" media="screen" />
    
      <h1> Student List 1</h1>
		
      <table class="w3-table-all"> 
         <?php 
            $i = 1; 
            echo "<tr class='w3-light-grey'>"; 
            echo "<td>Sr#</td>"; 
            echo "<td>Roll No.</td>"; 
            echo "<td>Name</td>"; 
            echo "<td>Name</td>"; 
            echo "<td>Edit</td>"; 
            echo "<td>Delete</td>"; 
            echo "<tr>"; 
				
            foreach($records as $r) { 
               echo "<tr>"; 
               echo "<td>".$i++."</td>"; 
               echo "<td>".$r['roll_no']."</td>"; 
               echo "<td>".$r['name']."</td>"; 
                echo "<td>".$r['email']."</td>"; 
               echo "<td><a href = '".base_url()."index.php/stud/edit/"
                  .$r['roll_no']."'>Edit</a></td>"; 
               echo "<td><a onclick='return doconfirm()' href = '".base_url()."index.php/stud/delete/"
                  .$r['roll_no']."'>Delete</a></td>"; 
               echo "<tr>"; 
            } 
         ?>
      </table> 
      <a href = "<?php echo base_url(); ?>index.php/stud/add_view">Add</a>
		
 
	
