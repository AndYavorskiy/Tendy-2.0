import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-attachments-layout',
  templateUrl: './attachments-layout.component.html',
  styleUrls: ['./attachments-layout.component.scss']
})
export class AttachmentsLayoutComponent implements OnInit {

  public ideaId: number;

  constructor(private route: ActivatedRoute) { }

  public ngOnInit() {
    this.route.params.subscribe(params => this.ideaId = +params['id'])
  }

}
