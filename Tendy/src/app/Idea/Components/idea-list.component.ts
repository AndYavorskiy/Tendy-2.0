import { Component, OnInit, Inject } from '@angular/core';
import { IdeaService } from '../Services/idea.service';
import { IdeaModule } from '../idea.module';
import { IdeaModel } from '../Models/idea.model';

@Component({
  selector: 'app-idea-list',
  templateUrl: './idea-list.component.html',
  styleUrls: ['./idea-list.component.css']
})
export class IdeaListComponent implements OnInit {

  ideas: IdeaModel[];

  constructor(private ideaService: IdeaService) { }

  ngOnInit() {
    // this.ideaService.getAllIdeas()
    //   .subscribe(result => this.ideas = result)
  }

}
