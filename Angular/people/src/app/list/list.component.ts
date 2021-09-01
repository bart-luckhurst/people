import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { PeopleListState } from '../PeopleListState';
import { Person } from '../Person';
import { PersonService } from '../person.service';
import { StateService } from '../state.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {

  people?: Person[];
  peopleSubscription: Subscription = new Subscription();
  getPeopleSubscription: Subscription = new Subscription();

  constructor(private personService: PersonService) { }

  async ngOnInit(): Promise<void> {
    this.peopleSubscription = this.personService.people$.subscribe(allPeople => {
      this.people = allPeople;
    });
    if (!this.people) {
      this.getPeopleSubscription = this.personService.getAllPeople().subscribe();
    }
  }

  ngOnDestroy(): void {
    this.peopleSubscription.unsubscribe();
    this.getPeopleSubscription.unsubscribe();
  }
}
