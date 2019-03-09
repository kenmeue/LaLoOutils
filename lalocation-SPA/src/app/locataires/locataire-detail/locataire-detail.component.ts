import { Component, OnInit } from '@angular/core';
import { Locataire } from 'src/app/_models/locataire';
import { LocataireService } from 'src/app/_services/locataire.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-locataire-detail',
  templateUrl: './locataire-detail.component.html',
  styleUrls: ['./locataire-detail.component.css']
})
export class LocataireDetailComponent implements OnInit {
  locataire: Locataire;

  constructor(private locataireService: LocataireService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
     this.loadLocataire();
     
  }

  loadLocataire() {
    this.locataireService.getLocataire(this.route.snapshot.params['id']).subscribe((locataire: Locataire) => {
      this.locataire = locataire;
      console.log(this.locataire);
    },
    error => {
      this.alertify.error(error);
    });
  }

}
