import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IdeaService } from '../services';

@Component({
    selector: 'app-idea-side-menu',
    templateUrl: './idea-side-menu.component.html',
    styleUrls: ['./idea-side-menu.component.scss'],
})
export class IdeaSideMenuComponent {

    public isToggled: boolean = false;

    constructor(route: ActivatedRoute,
	   private ideaService: IdeaService) {
	   route.params.subscribe(params => console.log("side menu id parameter", params['id']));
    }

    public toggle() {
	   this.isToggled = !this.isToggled;
    }

    public hide() {
	   this.isToggled = false;
    }
}