import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IdeaService } from '../Services';

@Component({
  selector: 'app-idea-side-menu',
  templateUrl: './idea-side-menu.component.html',
  styleUrls: ['./idea-side-menu.component.scss']
})
export class IdeaSideMenuComponent implements OnInit {

  constructor(route: ActivatedRoute,
    private ideaService: IdeaService) {
    route.params.subscribe(params => console.log("side menu id parameter", params['id']));
  }

  ngOnInit() {
  }

}
