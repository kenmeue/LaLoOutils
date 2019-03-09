import { Component, OnInit } from '@angular/core';
import { LocataireService } from 'src/app/_services/locataire.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Locataire } from 'src/app/_models/locataire';

@Component({
  selector: 'app-locataire-list',
  templateUrl: './locataire-list.component.html',
  styleUrls: ['./locataire-list.component.css']
})
export class LocataireListComponent implements OnInit {
  locataires: Locataire[];

  constructor(private locataireservice: LocataireService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadLocataires();
  }
  loadLocataires() {
    this.locataireservice.getLocataires().subscribe((locataires: Locataire[]) => {
      this.locataires = locataires;
      console.log(this.locataires);
  }, error => {
    this.alertify.error(error);
  });

}
}
