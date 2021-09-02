import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { PeopleListState } from './PeopleListState';

@Injectable({
  providedIn: 'root'
})
export class StateService {

  state$: Subject<PeopleListState> = new Subject();
  private state: PeopleListState = PeopleListState.Intial;

  constructor() { }

  public goToState(state: PeopleListState): void {
    this.state = state;
    this.state$.next(this.state);
  }
}
