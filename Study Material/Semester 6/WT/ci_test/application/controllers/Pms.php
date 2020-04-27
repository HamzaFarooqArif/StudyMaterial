<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');
//Project management System
class Pms extends CI_Controller {
       
	public function __construct()
	{
		parent::__construct();
                //$this->load->helper('url','date','myPagination');
                //$this->load->library('session');
		        $this->load->library('grocery_CRUD');
        }
    
        
        public function index()
        {
            
            $this->load->view('epsView/header');
            $this->load->view('epsView/home');
          
            
        }
               
        
         public function booking()
	{
			$this->load->model('eps_model');		
                        $data['title']= 'Home';
                        $data['packages'] = $this->eps_model->get_packages();
                        $data['services'] = $this->eps_model->get_services();
                        $data['timeslots'] = $this->eps_model->get_timeslots();
                     	//$this->load->$view('userView/header_view',$data);
			$this->load->view("epsView/header");
            $this->load->view("epsView/bookingView.php", $data);
                    
	}
        
        public function departments_management()
	{
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('departments');
            $crud->display_as('name','Department Name');
            $crud->set_subject('Department');
             $output = $crud->render();
             $this->load->view('projectView/header');
            $this->load->view('projectView/display_view', $output);
			
         }
         function unset_dml_operation($crud)
         {
             $crud->unset_add();
             $crud->unset_edit();
             $crud->unset_delete();
             $crud->unset_print();
             $crud->unset_export();
             
             
         }
      public function positions_management()
	{
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('positions');
            $crud->set_subject('Position');
            if($this->session->userdata('user_type')!='Admin')
                $this->unset_dml_operation($crud);
            $crud->add_action('Competencies',base_url().'','pms/position_competency_management');
            $output = $crud->render();
            $this->load->view('projectView/display_view', $output);
			
         }
     
       public function competencies_management()
	{
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('competencies');
            $crud->set_subject('Competency');
            if($this->session->userdata('user_type')!='Admin')
                $this->unset_dml_operation($crud);
            $output = $crud->render();
            $this->load->view('projectView/header');
            $this->load->view('projectView/display_view', $output);
			
         }
        public function position_competency_management()
	{   $this->load->model('project_model');            
            $position_id = $this->uri->segment(3);
            $_SESSION['position_id']=$position_id;
            $_SESSION['position']=$this->project_model->get_position($position_id);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('position_competency');
            if($this->session->userdata('user_type')!='Admin')
                $this->unset_dml_operation($crud);
            $crud->add_fields('positionTitle','competency_id');
            $crud->field_type('position_id', 'hidden');
            $crud->callback_before_insert(array($this,'set_some_field'));
            $crud->where('position_id',$position_id);
            $crud->callback_add_field('positionTitle',array($this,'add_field_callback_title'));
            $crud->callback_add_field('position_id',array($this,'add_field_callback_position'));
            $crud->set_subject('Competency');
            $crud->set_relation('position_id', 'positions', 'title');
            $crud->set_relation('competency_id', 'competencies', 'code');
            $output = $crud->render();
            $this->load->view('projectView/header');
            $this->load->view('projectView/display_view', $output);
			
         }
             public function team_management()
	{
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('team');
            $crud->set_subject('team');
            $crud->set_relation('leader', 'user', 'username');
            //if($this->session->userdata('user_type')!='Admin')
            //    $this->unset_dml_operation($crud);
            $crud->add_action('members',base_url().'','pms/teamDetail_management');
            $output = $crud->render();
            $this->load->view('projectView/header');
            $this->load->view('projectView/display_view', $output);
			
         }
         public function teamDetail_management()
	{   $this->load->model('project_model');            
            $team_id = $this->uri->segment(3);
            $_SESSION['team_id']=$team_id;
            //$_SESSION['team']=$this->project_model->get_team($team_id);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('teamdetail');
            $crud->where('teamId',$team_id);
            $crud->display_as('teamId','TeamTitle');
            $crud->display_as('memberId','Member');
            //$crud->callback_add_field('positionTitle',array($this,'add_field_callback_title'));
            $crud->callback_add_field('teamId',array($this,'add_field_callback_team'));
            $crud->set_subject('New Member');
            $crud->set_relation('memberId', 'user', 'username');
            $crud->set_relation('teamId', 'team', 'title');
            $crud->callback_add_field('status',array($this,'add_field_callback_mstatus'));
            $crud->callback_edit_field('status',array($this,'edit_field_callback_mstatus'));
          //$crud->set_relation('competency_id', 'competencies', 'code');
            $output = $crud->render();
            $this->load->view('projectView/header');
            $this->load->view('projectView/display_view', $output);
			
         }
         
          public function projfeasibility_management()
	{
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('projectfeasibility');
            $crud->set_subject('New ProjectProposal');
            $crud->set_relation('teamId', 'team', 'title');
             $crud->columns('projectDescription','TentativeBudget','timeConstraint');
            //if($this->session->userdata('user_type')!='Admin')
            //    $this->unset_dml_operation($crud);
            //$crud->add_action('members',base_url().'','pms/teamDetail_management');
            $output = $crud->render();
            $this->load->view('projectView/header');
            $this->load->view('projectView/display_view', $output);
			
         }


          public function order_management()
    { 
            
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('orders');
            $crud->set_subject('My Orders');
            // $crud->set_relation('jobtitle', 'positions', 'title');
            // $crud->set_relation('deptno', 'departments', 'code');
            // $crud->add_action('CoreCompetencies',base_url().'','pms/emp_competency_management');
            $output = $crud->render();
            $this->load->view('display_view', $output);

         }


  public function order_detail_management()
    {
            $empno = $this->uri->segment(3);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('emp_core_competencies');
            $crud->where('employee_id',$empno);
            $crud->display_as('employee_id', 'Employee');
            $crud->display_as('competency_id', 'CoreCompetency');
            $crud->set_subject('Core Competency');
            $crud->set_relation('employee_id', 'employees', 'name');
            $crud->set_relation('competency_id', 'competencies', 'code');
            $output = $crud->render();
            $this->load->view('display_view', $output);
            
         }



        public function employees_management()
	{ 
            
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('employees');
            $crud->set_subject('Employee');
            // $crud->set_relation('jobtitle', 'positions', 'title');
            // $crud->set_relation('deptno', 'departments', 'code');
            $crud->add_action('CoreCompetencies',base_url().'','pms/emp_competency_management');
            $output = $crud->render();
            $this->load->view('projectView/header');
            $this->load->view('projectView/display_view', $output);

         }
         
        public function emp_competency_management()
	{
            $empno = $this->uri->segment(3);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('emp_core_competencies');
            $crud->where('employee_id',$empno);
            $crud->display_as('employee_id', 'Employee');
            $crud->display_as('competency_id', 'CoreCompetency');
            $crud->set_subject('Core Competency');
            $crud->set_relation('employee_id', 'employees', 'name');
            $crud->set_relation('competency_id', 'competencies', 'code');
            $output = $crud->render();
            $this->load->view('display_view', $output);
			
         }


        public function orders_management()
	{ $this->load->model('eps_model'); 
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            
            $crud->set_table('order');
            $crud->columns('id','cid','odate','status');
            //if($this->session->userdata('user_type')!='Admin')
            //  $this->unset_dml_operation($crud);
            $crud->display_as('id','OrderNo');
            $crud->display_as('cid','Client');
            $crud->display_as('odate','Date');
            $crud->set_relation('cid', 'user', 'username');
            $crud->add_action('Packages',base_url().'','eps/packages_booked');
            $crud->add_action('OtherServices',base_url().'','eps/services_booked');
            $crud->add_action('TimeSots',base_url().'','eps/slots_booked');
           // $crud->callback_add_field('status',array($this,'add_field_callback_status'));
           // $crud->callback_edit_field('status',array($this,'edit_field_callback_status'));
            //$crud->set_subject('Project');
            $output = $crud->render();
            $this->load->view('epsView/header');
            $this->load->view('epsView/display_view', $output);
			
         }
         public function packages_booked()
	{              
            $this->load->model('eps_model');            
            $pid = $this->uri->segment(3);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('orderdetailpackage');
            $crud->where('oid',trim($pid));
            $crud->set_relation('pid', 'packages', 'name');
            $crud->add_action('Detail',base_url().'','eps/packages_detail');
            $output = $crud->render();
            $this->load->view('epsView/header');
            $this->load->view('epsView/display_view',$output);
	} 

        public function packages_detail()
	{              
            $this->load->model('eps_model');            
            $pid = $this->uri->segment(3);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('packagesdetail');
            $crud->where('pid',trim($pid));
            $crud->set_relation('sid', 'services', 'name');
            $output = $crud->render();
            $this->load->view('epsView/header');
            $this->load->view('epsView/display_view',$output);
	} 
        public function services_booked()
	{              
            $this->load->model('eps_model');            
            $pid = $this->uri->segment(3);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('orderdetailservices');
            $crud->columns('sid');
            $crud->display_as('sid','Services');
            $crud->where('oid',trim($pid));
            $crud->set_relation('sid', 'services', 'name');
            $output = $crud->render();
            $this->load->view('epsView/header');
            $this->load->view('epsView/display_view',$output);
	} 
        
        public function slots_booked()
	{              
            $this->load->model('eps_model');            
            $pid = $this->uri->segment(3);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('orderdetailtimeslots');
            $crud->columns('tid');
            $crud->display_as('tid','TimeSlots');
            $crud->where('oid',trim($pid));
            $crud->set_relation('tid', 'timeslots', 'slots');
            $output = $crud->render();
            $this->load->view('epsView/header');
            $this->load->view('epsView/display_view',$output);
	} 

        public function tasks_management()
	{
            $this->load->model('project_model');
            $id = $this->uri->segment(3);
            $_SESSION['rid']=$id;
            $_SESSION['req']=$this->project_model->get_requirement($id);
            $crud = new grocery_CRUD();
            $crud->set_theme('datatables');
            $crud->set_table('tasks');
             $crud->columns('title','priority','category','effort');
            if($this->session->userdata('user_type')!='Admin')
                $this->unset_dml_operation($crud);
            $crud->callback_add_field('rid',array($this,'add_field_callback_rid'));
            $crud->callback_add_field('description',array($this,'add_field_callback_desc'));
            $crud->callback_edit_field('description',array($this,'edit_field_callback_tdesc'));
            $crud->callback_add_field('status',array($this,'add_field_callback_status'));
            $crud->callback_edit_field('status',array($this,'edit_field_callback_status'));
            $crud->unset_columns('rid');
            $crud->where('rid',trim($id));
            $crud->order_by('priority','desc');
            $crud->set_subject('Task');
            $output = $crud->render();
            $this->load->view('projectView/header');
            $this->load->view('projectView/display_view', $output);
	    }
            
           
          public function updateTasks() 
            { 
            $this->load->model('project_model');
            $this->project_model->updateTasks(); 
            }   
          public function updateDailyTasks()
            {
            $this->load->model('project_model');
            $this->project_model->updateDailyTasks();
            }   
          public function updateReviewTasks()
            {
            $this->load->model('project_model');
            $this->project_model->updateReviewTasks();
            }   
            
          function add_field_callback_pid()
            { 
            return '<input type="text" name="pcode" value="'.$_SESSION['pcode'].'" readonly/>';
            }
          function add_field_callback_rid()
            { 
                    return '<input type="text" name="rid" value="'.$_SESSION['rid'].'" readonly/>';
            }

          function add_field_callback_desc()
            { 
                return '<textarea name="description" row=4 cols=50>
                    </textarea>';
            }
          function add_field_callback_status()
            { 
                 return ' <input type="checkbox" name="status"  value="Complete" /> Complete';
            }
            function edit_field_callback_status()
            { 
                 return ' <input type="checkbox" name="status"  value="Complete" /> Complete';
            }

            
            
              function add_field_callback_mstatus()
            { 
                 return ' <input type="checkbox" name="status"  value="InActive" /> InActive';
            }
            function edit_field_callback_mstatus()
            { 
                 return ' <input type="checkbox" name="status"  value="InActive" /> InActive';
            }

            
            function edit_field_callback_desc()
            {              

               return '<textarea name="description" row=4 cols=50>'.
                            $this->desc().'</textarea>';
            }
            function desc()
            {   $this->load->model('project_model');
                $pcode = $this->uri->segment(4);
                $project=$this->project_model->get_projects($pcode);
                return $project[0]['description'];
            }
            function add_field_callback_position()
            { 
                 return '<input type="text" name="position_id" value="'.$_SESSION['position'][0]['id'].'" />';
            }
             function add_field_callback_team()
            { 
                 return '<input type="text" name="teamId" value="'.$_SESSION['team_id'].'"  readonly/> ';
            }
            function add_field_callback_title()
            { 
                 return '<input type="text" name="position_id" value="'.$_SESSION['position'][0]['title'].'" readonly/>';
            }
            function edit_field_callback_rdesc()
            {              

                 return '<textarea name="description" row=4 cols=50>'.
                            $this->rdesc().'</textarea>';
            }
            function rdesc()
            {   $this->load->model('project_model');
                $pcode = $this->uri->segment(5);
                $req=$this->project_model->get_requirement($pcode);
                return $req[0]['description'];
            }

            function edit_field_callback_tdesc()
            {              

                return '<textarea name="description" row=4 cols=50>'.
                            $this->tdesc().'</textarea>';
            }
            function tdesc()
            {    $this->load->model('project_model');
                $pcode = $this->uri->segment(5);
                $req=$this->project_model->get_task($pcode);
                return $req[0]['description'];
            }      
         public function projects()
        {
           $this->load->model('project_model');
           $table="tasks";
           $cols= array ('rid','title','priority','category');
           $where= "category='CSS'";
           $data['table'] = $this->project_model->get_data($cols,$table, $where);
           $data['colsHeading']= array ('Req Id','TaskTitle','Priority','Category');
           $data['cols']=$cols;
           $data['reportHeading']='Tasks List';
           $this->load->view('projectView/header');
           $this->load->view('reportView/table1',$data); 
        }
         public function competencies()
        {
           $this->load->model('project_model');
           $table="competencies";
           $cols= array ('id','code','description');
           $data['table'] = $this->project_model->get_data($cols, $table);
           $data['colsHeading']= array ('Id','ShortName','Title');
           $data['cols']=$cols;
           $data['reportHeading']='Competencies List';
           $this->load->view('projectView/header');
           $this->load->view('reportView/table1',$data); 
        }
	
public function projectDetail()
        {
           $this->load->model('project_model');
           $table="projectreportsview";
           $cols= array ('pCode','pTitle','rTitle','tTitle','uName','Start_Time','End_Time','TimeSpent','ToDate');
           $where= " uName is not null";
           $data['table'] = $this->project_model->get_data($cols,$table, $where);
           $data['colsHeading']= array ('ProjectCode','Title','ModuleTitle','TaskTitle','uName','Start_Time','End_Time','TimeSpent','Date');
           $data['cols']=$cols;
           $data['reportHeading']='Projects  Detail';
           $this->load->view('projectView/header');
           $this->load->view('reportView/table1',$data); 
        }
        public function scoreBoard()
        {
           $this->load->model('project_model');
           $cols= array ('uName','tTitle','taskType','Hour','Minute');
           $data['table'] = $this->project_model->getCompletedTasks();
           $data['colsHeading']= array ('Member','Task','TaskType','Hour', 'Minute');
           $data['cols']=$cols;
           $data['reportHeading']='Completed Tasks';
           $this->load->view('projectView/header');
           $this->load->view('reportView/table1',$data); 
        }
        public function member_progress()
        {
           if ($this->input->post('uId') =='')
           {
               //echo ' no member is seleted';
               $userId=9; //default user
               $old_date = date('y-m-d-h-i-s');            // works
               $middle = strtotime($old_date);             // returns bool(false)
               $new_date = date('Y-m-d', $middle);  
               
           }
           else
           {
             //echo ' member '.$this->input->post('uId'). ' is selected';  
             $userId=$this->input->post('uId');
             $date1=$this->input->post('startdate');
             $middle = strtotime($date1);             // returns bool(false)
             $new_date = date('Y-m-d', $middle);  
             //echo $new_date.'  originaldate:'.$date1;
             //exit();
           }
           $data['userId'] =  $userId;
           $this->load->model('project_model');
           $data['members'] = $this->project_model->get_members();
           $table="projectreportsview";
           $cols= array ('pCode','pTitle','rTitle','tTitle','uName','Start_Time','End_Time','TimeSpent','ToDate');
           $where= " uId=". $userId. " AND ToDate >='".$new_date. "'";
           $data['table'] = $this->project_model->get_data($cols,$table, $where);
           $data['totalEffort'] = $this->project_model->getTotalTime($userId, $new_date);
           $data['colsHeading']= array ('Project','Title','ModuleTitle','TaskTitle','uName','Start_Time','End_Time','TimeSpent','Date');
           $data['cols']=$cols;
           $data['reportHeading']='Member Progress';
           $this->load->view('projectView/header');
           $this->load->view('reportView/memberProgress',$data); 
        }

}

