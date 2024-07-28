import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiConfig } from 'src/api.config';
import { MessageService } from 'src/app/messages/services/message.service';
import { Weight } from '../models/weight';
import { BehaviorSubject, Observable, catchError, of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WeightService {
  private weightUrl = `${apiConfig.baseUrl}:${apiConfig.port}/api/weightregistries`;
  private weightsSource = new BehaviorSubject<Weight[] | undefined>(undefined);
  currentWeights = this.weightsSource.asObservable();

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  private log(message: string) {
    this.messageService.add(`WeightsService: ${message}`);
  }

  loadWeights(petid: number): Observable<Weight[]> {
    return this.http.get<Weight[]>(`${this.weightUrl}/${petid}`).pipe(
      tap((weights) => {
        this.log(`getting weight data for pet ${petid}`);
        this.weightsSource.next(weights); // Update the current weight data
      }),
      catchError(this.handleError<Weight[]>('loadWeight', undefined))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
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
