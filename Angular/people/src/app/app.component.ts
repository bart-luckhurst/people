import { state } from '@angular/animations';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription, SubscriptionLike } from 'rxjs';
import { PeopleListState } from './PeopleListState';
import { PersonService } from './person.service';
import { StateService } from './state.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  state?: PeopleListState;
  stateServiceSubscription: Subscription = new Subscription();
  PeopleListState = PeopleListState;

  constructor(private personService: PersonService,
    private stateService: StateService) {
  }

  async ngOnInit(): Promise<void> {
    this.stateServiceSubscription = this.stateService.state$.subscribe(x => {
      this.state = x;
    });

    await this.loadPeople();
  }

  ngOnDestroy(): void {
    this.stateServiceSubscription.unsubscribe();
  }

  private async loadPeople(): Promise<void> {
    try {
      //show loading state
      this.stateService.goToState(PeopleListState.Loading);
      //load people
      await this.personService
        .getAllPeople()
        .toPromise();
      //show ready state
      this.stateService.goToState(PeopleListState.Ready);
    }
    catch (err) {
      //show error state
      this.stateService.goToState(PeopleListState.Error);
    }
  }
}
