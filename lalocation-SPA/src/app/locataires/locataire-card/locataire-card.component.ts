import { Component, OnInit, Input } from '@angular/core';
import { Locataire } from 'src/app/_models/locataire';

@Component({
  selector: 'app-locataire-card',
  templateUrl: './locataire-card.component.html',
  styleUrls: ['./locataire-card.component.css']
})
export class LocataireCardComponent implements OnInit {
  @Input() locataire: Locataire;
  constructor() { }

  ngOnInit() {
  }

}
