//
//  CollectionViewCell.swift
//  IOS-Swift-UICollectionViewDynamicCustom
//
//  Created by Pooya on 2018-09-27.
//  Copyright © 2018 Pooya. All rights reserved.
//

import UIKit

protocol DataCollectionProtocol {
    func passData(index : Int)
    func deleteData(index : Int)
}

class CollectionViewCell: UICollectionViewCell {
    
    var index : IndexPath?
    var delegate : DataCollectionProtocol?
    
    @IBOutlet weak var imageCell: UIImageView!
    @IBOutlet weak var labelAfterDate: UILabel!
    @IBOutlet weak var labelNowDate: UILabel!
    @IBOutlet weak var labelName: UILabel!
    
    @IBOutlet weak var new_button: UIButton!
    
}
