import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdCardService {
  default_card_img = "assets/images/default.jpg"
  get adCard () {
    return [
      {
        city: "Westminster, CA",
        content: "NEW TOWNHOUSE ở Westminster góc Beach and 13rd Street, rộng 1,500SF, 3PN/2.5PT, 2 car garages. No pet, No smoking $2,600/ tháng. Ready move-in June 1st",
        contact: "Oanh 949-874-4766",
        address: "",
        img: this.default_card_img,
        time: "8:15 PM"
      },
      {
        city: "Fountain Valley, CA",
        content: "Nhà 3PN/1.5PT, remodel, enclosed patio làm phòng ngủ thứ 4, Housing ONLY. Refrigerator, washer & dryer. No central AC. Góc McFadden/Magnolia gần Saigon City. $2,550/month + Deposit, dọn anytime, Nhà 3PN/1.5PT, remodel, enclosed patio làm phòng ngủ thứ 4, Housing ONLY. Refrigerator, washer & dryer. No central AC. Góc McFadden/Magnolia gần Saigon City. $2,550/month + Deposit, dọn anytime, Nhà 3PN/1.5PT, remodel, enclosed patio làm phòng ngủ thứ 4, Housing ONLY. Refrigerator, washer & dryer. No central AC. Góc McFadden/Magnolia gần Saigon City. $2,550/month + Deposit, dọn anytime",
        contact: "657-204-2717",
        address: "",
        img: this.default_card_img,
        time: "11:00 AM"
      },
      {
        city: "Westminster, CA",
        content: "Westminster, 2 Beds, 1 Bath. Upper, rộng, thoáng, yên tịnh, nhiều parking. Housing approved $1,900. Deposit: $1,900. Dọn anytime",
        contact: "714-470-3934",
        address: "6531 Westpark Place. # F, Westminster, CA 92683",
        img: this.default_card_img,
        time: "Yesterday"
      },
      {
        city: "Santa Ana, CA",
        content: "Santa Ana McFadden Ave./ Euclid gần nhà thờ St.Barbara, khu yên tĩnh, gần nhà thờ, chợ. 3PN/2½PT + Den, 2 story, year 1990. Housing only. Vacant, dọn anytime",
        contact: "Kim: 714-588-8351",
        address: "",
        time: "May 27, 2020"
      },
      {
        city:"Westminster, CA",
        content: "Vacation Home (Phước Lộc Thọ) xây 2017 rất đẹp, Trung Tâm Little Saigon, sau chợ Mỹ Thuận, 4PN/3PT, 4PN/3½PT. Có máy giặt sấy.",
        contact: "Vân: 714-622-9089, Chí: 714-683-7647, Huy: 714-829-6578",
        address: "",
        img: this.default_card_img,
        time: "October 26, 2019"
      },
      {
        city: "Fountain Valley, CA",
        content: "Nhà Fountain Valley gần nhà thờ Thánh Linh mới xây. 3BRs 2BTHs. Không garage. Có nhiều parking trước nhà. Nhận housing $2800/tháng & deposit.",
        contact: "Van 714-390-7861",
        address: "",
        img: this.default_card_img,
        time: "December 27, 2018"

      },
    ]

  }
  constructor() { }
}
