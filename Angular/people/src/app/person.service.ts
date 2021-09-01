import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy, OnInit } from '@angular/core';
import { Observable, of, Subject, Subscription, SubscriptionLike } from 'rxjs';
import { tap } from "rxjs/operators";
import { Person } from './Person';

@Injectable({
  providedIn: 'root'
})
export class PersonService implements OnInit, OnDestroy {

  people$: Subject<Person[]> = new Subject();
  updatePeople$: Subject<void> = new Subject();

  selectedPerson?: Person;

  getPeopleSubscription: Subscription = new Subscription();

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.updatePeople$.subscribe(x => {
      this.getAllPeople().subscribe();
    });
  }

  ngOnDestroy(): void {
    this.getPeopleSubscription.unsubscribe();
  }
  
  create(forename: string,
    surname: string): Observable<Person> {
      let url = 'https://localhost:44367/api/people';
      let body = { "forename": forename, "surname": surname }
      let response = this.http.post<Person>(url, body)
        .pipe(tap(() =>  {
          this.updatePeople$.next();
        }));
      return response;
  }

  getAllPeople(): Observable<Person[]> {
    let url = 'https://localhost:44367/api/people';
    let response = this.http.get<Person[]>(url)
      .pipe(tap((allPeople: Person[]) =>  { 
        this.people$.next(allPeople);
      }));
    return response;
  }

  update(personId: string,
    forename: string,
    surname: string): Observable<Person> {
      let url = 'https://localhost:44367/api/people/' + personId;
      let body = { "forename": forename, "surname": surname }
      let response = this.http.put<Person>(url, body)
        .pipe(tap(() =>  {
          this.updatePeople$.next();
        }));
      return response;
  }

  delete(personId: string): Promise<Object> {
    let url = 'https://localhost:44367/api/people/' + personId;
    let response = this.http.delete(url)
      .pipe(tap(() =>  {
        this.updatePeople$.next();
      })).toPromise<Object>();
    return response;
  }

  selectPerson(person: Person): void {
    this.selectedPerson = person;
  }
}
