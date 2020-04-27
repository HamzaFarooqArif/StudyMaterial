//
//  DetailsViewController.swift
//  IOS-Swift-UICollectionViewDynamicCustom
//
//  Created by Hamza Farooq on 12/14/19.
//  Copyright © 2019 Pooya. All rights reserved.
//

import UIKit

class DetailsViewController: UIViewController {
    var name = ""
    var image: UIImage!

    
    
    @IBOutlet weak var image_view_new: UIImageView!
    
    @IBOutlet weak var image_view_name: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
        image_view_name.text = name
        image_view_new.image = image
    }
 
    
    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}
