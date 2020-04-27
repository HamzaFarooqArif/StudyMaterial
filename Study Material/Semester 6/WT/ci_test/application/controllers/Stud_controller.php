<?php 
   class Stud_controller extends CI_Controller {
	
      function __construct() { 
         parent::__construct(); 
         $this->load->helper('url'); 
         $this->load->database();
         $this->load->model('Stud_Model'); 
      } 
  
      public function index() { 
        
         $stdData=$this->Stud_Model->getData1(); 
         $data['records'] = $stdData;  
			$this->load->view('header');
         $this->load->view('Stud_view1',$data); 
         $this->load->view('footer');
      } 
  
      public function add_student_view() { 
         $this->load->helper('form'); 
         $this->load->view('header');
         $this->load->view('Stud_add'); 
      } 
  
      public function add_student() { 
         
			$data['roll_no']= $this->input->post('roll_no');
         $data['name']= $this->input->post('name');
         $data['email']= $this->input->post('email');
			$this->Stud_Model->create($data);

         // $data = array( 
         //    'roll_no' => $this->input->post('roll_no'), 
         //    'name' => $this->input->post('name') 
         // ); 
         // //$this->Stud_Model->insert($data); 
   
         $query = $this->db->get("stud"); 
         $data['records'] = $query->result(); 
         $this->load->view('header');
         $this->load->view('Stud_view',$data); 
         $this->load->view('footer');
      } 
  
      public function update_student_view() { 
         $this->load->helper('form'); 
         $roll_no = $this->uri->segment('3'); 
         $query = $this->db->get_where("stud",array("roll_no"=>$roll_no));
         $data['records'] = $query->result(); 
         $data['old_roll_no'] = $roll_no; 
          $this->load->view('header');
         $this->load->view('Stud_edit',$data); 
      } 
  
      public function update_student(){ 
         
         			
         $data = array( 
            'roll_no' => $this->input->post('roll_no'), 
            'name' => $this->input->post('name') 
         ); 

         $old_roll_no = $this->input->post('old_roll_no');
         // echo  $old_roll_no;
         // echo $this->input->post('name'); exit;

         $this->Stud_Model->update($data,$old_roll_no); 
			
         $query = $this->db->get("stud"); 
         $data['records'] = $query->result(); 
          $this->load->view('header');
         $this->load->view('Stud_view',$data); 
          $this->load->view('footer');
      } 
  
  
      public function delete_student() { 
        
         $roll_no = $this->uri->segment('3'); 
        
        $this->Stud_Model->delete($roll_no); 
   
         $query = $this->db->get("stud"); 
         $data['records'] = $query->result();
          $this->load->view('header'); 
         $this->load->view('Stud_view',$data); 
         $this->load->view('footer');
      } 
   } 
?>