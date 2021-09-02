import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { PeopleListState } from '../PeopleListState';
import { StateService } from '../state.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  state?: PeopleListState;
  stateServiceSubscription: Subscription = new Subscription();
  PeopleListState = PeopleListState;

  constructor(private stateService: StateService) { }

  ngOnInit(): void {
    this.stateService.state$.subscribe(x => {
      this.state = x;
    });
  }

  showCreate(): void {
    this.stateService.goToState(PeopleListState.Create);
  }

}
