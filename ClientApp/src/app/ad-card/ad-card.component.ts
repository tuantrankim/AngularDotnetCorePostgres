import { Component, OnInit } from '@angular/core';
import { AdCardService } from './../services/ad-card.service';

@Component({
  selector: 'app-ad-card',
  templateUrl: './ad-card.component.html',
  styleUrls: ['./ad-card.component.css']
})
export class AdCardComponent implements OnInit {
  cards;
  constructor(service: AdCardService) {
    this.cards = service.adCard;
  }

  ngOnInit() {
  }

}
