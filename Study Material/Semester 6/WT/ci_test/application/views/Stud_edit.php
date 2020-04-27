
      
         <?php 
             foreach($records as $r) { 

            echo form_open('Stud_controller/update_student');
            echo form_hidden('old_roll_no',$old_roll_no); 
            echo form_label('Roll No.'); 
            echo form_input(array('id'=>'roll_no','name'=>'roll_no','value'=>$old_roll_no)); 
            echo "<br/>"; 
         
            echo form_label('Name'); 
            echo form_input(array('id'=>'name','name'=>'name','value'=>$r->name)); 
            echo "<br/>"; 
         
            echo form_submit(array('id'=>'submit','value'=>'Update')); 
           }
            echo form_close(); 
        
         ?> 
			
      </form> 
   </body>
	
</html>