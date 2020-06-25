import { Component, OnInit } from '@angular/core';
import { Category } from '../models/Category';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  
  categories_full: Category[] = [
    { id: 9, name: "Cần Thợ Hair, Nails (Hair, Nail Jobs)", categoryGroupId: 3, icon:"dry", categoryGroupName: null },
    { id: 1, name:"Phòng	Cho Thuê (Rooms to Share)", categoryGroupId: 1, icon:"meeting_room", categoryGroupName: null },
    { id: 6, name:"Mua Bán Xe (Cars for Sale)", categoryGroupId: 2, icon:"drive_eta", categoryGroupName: null },
    { id: 17, name:"Việc Làm (Employment)", categoryGroupId: 3, icon:"people", categoryGroupName: null },
    { id: 2, name: "Apt. Condo Cho Thuê (Apt. Condo for Rent)", categoryGroupId: 1, icon:"apartment", categoryGroupName: null },
    { id: 20, name:"Sang Nhượng Cơ Sở (Business Opportunities)", categoryGroupId: 4, icon:"store_mall_directory", categoryGroupName: null },
    { id: 21, name:"Mua Bán Nhà (Real Estate)", categoryGroupId: 4, icon:"house", categoryGroupName: null },
    { id: 15, name:"Việc Chợ, Nhà Hàng (Restaurant, Supermarket)", categoryGroupId: 3, icon:"shopping_cart", categoryGroupName: null },
    { id: 24, name:"Xây Cất (Construction)", categoryGroupId: 5, icon:"construction", categoryGroupName: null },
    { id: 12, name:"Giúp Việc Nhà (Domestic Assistance)", categoryGroupId: 3, icon:"checkroom", categoryGroupName: null },
    { id: 39, name:"Các Dịch Vụ Khác (Miscellaneous)", categoryGroupId: 5, icon:"emoji_symbols", categoryGroupName: null },
    { id: 14, name:"Việc Văn Phòng (Office - Clerical Jobs)", categoryGroupId: 3, icon:"emoji_transportation", categoryGroupName: null },
    { id: 16, name:"Việc Thợ may (Sewing Jobs)", categoryGroupId: 3, icon:"content_cut", categoryGroupName: null },
    { id: 30, name:"Dạy Kèm (Tutoring)", categoryGroupId: 5, icon:"school", categoryGroupName: null },
    { id: 33, name:"Đấm Bóp & Thư Giãn (Massage)", categoryGroupId: 5, icon:"spa", categoryGroupName: null },
    { id: 8, name:"Mua Bán Các Loại (Items for Sale)", categoryGroupId: 2, icon:"shopping_cart", categoryGroupName: null },
    { id: 25, name:"Sửa Điện, Nước (Electric, Plumbing)", categoryGroupId: 5, icon:"plumbing", categoryGroupName: null },
    { id: 26, name:"Sửa Máy Móc Gia Dụng (Appliances Repair)", categoryGroupId: 5, icon:"radio", categoryGroupName: null },
    { id: 13, name:"Việc Hãng Xưởng (Manufacturing Job)", categoryGroupId: 3, icon:"apartment", categoryGroupName: null },
    { id: 11, name:"Giữ Trẻ (Child Care)", categoryGroupId: 3, icon:"baby_changing_station", categoryGroupName: null }
  ];
  categories: Category[] = this.categories_full;

  public isExpand = false;
  successMessage: string = "";
  errorMessage: string = "";
  constructor(private service: PostService) {
  }

  ngOnInit() {
    this.getCategories();
  }

  public getCategories() {
    
    this.service.getAllCategories()
      .subscribe(data => {
        this.service.setAllCategories(data);
        this.onExpand();
        this.categories_full = data;
        this.successMessage = `(${this.categories.length} items)`;
      }, error => {
        this.errorMessage = error;
      }
      );
      
  }

  urlFriendly(str) {
    var url = str.substr(0, 200);
    return this.service.removeAccents(url).replace(/[^a-zA-Z0-9]/g, '-').replace(/--+/g, '-');
  }

  onExpand() {
    this.isExpand = !this.isExpand;
    //[...values].sort((a, b) => b - a).slice(0, 5);
    if (this.isExpand) {

      this.categories = [...this.categories_full];
    }
    else {
      this.categories = [...this.categories_full].slice(0, 20);
    }
  }

}
