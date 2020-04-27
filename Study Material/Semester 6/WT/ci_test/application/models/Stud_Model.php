<?php 
   class Stud_Model extends CI_Model {
	
      function __construct() { 
         parent::__construct(); 
      } 

   
    
   public function insert($data) { 
         if ($this->db->insert("stud", $data)) { 
            return true; 
         } 
      } 

 public function create($data) { 
      $x =$this->db->query("insert into stud (roll_no, name,email) values(".
      $data['roll_no'] . ",'".
      $data['name'] . "','".
      $data['email'].
      "')");
           
           // echo  $x. " Record Inserted successfully"; exit;
           // return true; 
         } 
       

    public function getData() { 
         //$recSet=$this->db->get("stud");
         $recSet=$this->db->query('select * from stud');
         $arrayFormat= $recSet->result();
         return $arrayFormat;    
         } 
      

         public function getData1() { 
         //$recSet=$this->db->get("stud");
         $recSet=$this->db->query('select * from stud');
         $arrayFormat= $recSet->result_array();//result();
         return $arrayFormat; 
         } 

     public function update($data,$old_roll_no) { 
        
         $this->db->set($data); 
         $x = $this->db->query("update stud set name= '".  $data['name'] ."' where roll_no = " . $old_roll_no);
         // echo " Record Updated successfully". $x; exit;
         // $this->db->where("roll_no", $old_roll_no); 
         // $this->db->update("stud", $data); 
      } 
   
      public function delete($roll_no) { 
      
      $x = $this->db->query("delete from stud WHERE roll_no = ".$roll_no);

       // if ($x) {echo "Record Deleted successfully"; exit;}
                

         // if ($this->db->delete("stud", "roll_no = ".$roll_no)) { 
         //    return true; 
         // } 
      } 
   

      
   } 
?> 