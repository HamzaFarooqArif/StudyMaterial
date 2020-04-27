 
         <?php 
            echo form_open('stud/add');
            echo form_label('Roll No.'); 
            echo form_input(array('id'=>'roll_no','name'=>'roll_no')); 
            			
            echo form_label('Name'); 
            echo form_input(array('id'=>'name','name'=>'name')); 
            echo "<br/>";
			   echo "Email: <input type='email' name='email' > ";
            echo form_submit(array('id'=>'submit','value'=>'Add')); 
            echo form_close(); 
         ?> 
   </body>
</html>