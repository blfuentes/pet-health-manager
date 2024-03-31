import { apiConfig } from "../../../api.config"; // Import the configuration
import { catchError, map, tap } from "rxjs/operators";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { MessageService } from "../../messages/services/message.service";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

import { Pet } from "../models/pet";

@Injectable({
  providedIn: "root",
})
export class PetsService {
  private petsUrl = `${apiConfig.baseUrl}:${apiConfig.port}/api/pets`;
  private petUrl = `${apiConfig.baseUrl}:${apiConfig.port}/api/pets`;

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  private log(message: string) {
    this.messageService.add(`PetsService: ${message}`);
  }

  getPets(): Observable<Pet[]> {
    return this.http.get<Pet[]>(this.petsUrl).pipe(
      tap((_) => this.log('fetched pets')),
      catchError(this.handleError<Pet[]>('getPets', []))
    );
  }

  loadPet(petid: number): Observable<Pet> {
     return this.http.get<Pet>(`${this.petUrl}/${petid}`).pipe(
       tap((_) => this.log(`getting data for pet ${petid}`)),
       catchError(this.handleError<Pet>('loadPet', undefined))
     );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
