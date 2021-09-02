import { compileDeclarePipeFromMetadata } from '@angular/compiler';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { PeopleListState } from '../PeopleListState';
import { Person } from '../Person';
import { PersonService } from '../person.service';
import { StateService } from '../state.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  forename: string = "";
  surname: string = "";

  constructor(private stateService: StateService,
    private personService: PersonService) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.clearForm();
    this.stateService.goToState(PeopleListState.Ready);
  }

  async onSubmit(): Promise<void> {
    let newPerson: Person = await this.personService
      .create(this.forename, this.surname)
      .toPromise();
    this.stateService.goToState(PeopleListState.Ready);
  }

  clearForm(): void {
    this.forename = "";
    this.surname = "";
  }

}
