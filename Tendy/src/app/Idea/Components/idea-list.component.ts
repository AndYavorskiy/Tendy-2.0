import { Component, OnInit, Inject } from '@angular/core';
import { IdeaService } from '../Services/idea.service';
import { IdeaModule } from '../idea.module';
import { IdeaModel } from '../Models/idea.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-idea-list',
  templateUrl: './idea-list.component.html',
  styleUrls: ['./idea-list.component.css']
})
export class IdeaListComponent implements OnInit {

  ideas: IdeaModel[];

  constructor(route: ActivatedRoute,
    private ideaService: IdeaService) {
    route.params.subscribe(params => console.log("side menu id parameter", params['id']));
  }

  ngOnInit() {
    // this.ideaService.getAllIdeas()
    //   .subscribe(result => this.ideas = result)
  }

}
