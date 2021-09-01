import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { PeopleListState } from '../PeopleListState';
import { Person } from '../Person';
import { PersonService } from '../person.service';
import { StateService } from '../state.service';

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.scss']
})
export class ListItemComponent implements OnInit, OnDestroy {

  @Input() person?: Person;
  deleteConfirmationVisible: boolean = false;
  getPeopleSubscription: Subscription = new Subscription();

  constructor(private personService: PersonService, private stateService: StateService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.getPeopleSubscription.unsubscribe();
  }

  public getInitials(person?: Person): string {
    if (person) {
      let forenameInitial: string = person.forename
      .trim()
      .charAt(0);
      let surnameInitial: string = person.surname
        .trim()
        .charAt(0);
      return forenameInitial + surnameInitial;
    }
    else {
      return "";
    }
  }

  public edit(personToEdit?: Person) {
    if (personToEdit) {
      this.personService.selectPerson(personToEdit);
      this.stateService.goToState(PeopleListState.Edit);
    }
  }

  public showDeleteConfirmation(): void {
    this.deleteConfirmationVisible = true;
  }

  public async delete(): Promise<void> {
    try {
      if (this.person) {
        await this.personService.delete(this.person?.personId);
        this.personService.getAllPeople().subscribe();
      }
    }
    catch(err) {
      console.log(err);
    }
  }

  public cancel(): void {
    this.deleteConfirmationVisible = false;
  }

}
