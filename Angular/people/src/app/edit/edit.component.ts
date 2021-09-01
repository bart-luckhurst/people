import { Component, Input, OnInit } from '@angular/core';
import { PeopleListState } from '../PeopleListState';
import { Person } from '../Person';
import { PersonService } from '../person.service';
import { StateService } from '../state.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  @Input() selectedPerson?: Person = {
    personId: "",
    forename: "",
    surname: "",
    dateTimeCreated: new Date(),
    dateTimeUpdated: new Date()
  };

  constructor(private stateService: StateService,
    private personService: PersonService) { }

  ngOnInit(): void {
    this.selectedPerson = this.personService.selectedPerson;
  }

  cancel(): void {
    this.stateService.goToState(PeopleListState.Ready);
  }

  async onSubmit(): Promise<void> {
    if (this.selectedPerson) {
      let updatedPerson: Person = await this.personService
        .update(this.selectedPerson.personId,
          this.selectedPerson.forename,
          this.selectedPerson.surname)
        .toPromise();
      this.stateService.goToState(PeopleListState.Ready);
    }
  }
}
