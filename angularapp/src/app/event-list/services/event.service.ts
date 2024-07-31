import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiConfig } from 'src/api.config';
import { MessageService } from 'src/app/messages/services/message.service';
import { EventAnnotation } from '../models/eventAnnotation';
import { BehaviorSubject, Observable, catchError, of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventAnnotationService {
  private eventAnnotationtUrl = `${apiConfig.baseUrl}:${apiConfig.port}/api/eventannotations`;
  private eventAnnotationsSource = new BehaviorSubject<EventAnnotation[] | undefined>(undefined);
  currentEventAnnotations = this.eventAnnotationsSource.asObservable();

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  private log(message: string) {
    this.messageService.add(`EventAnnotationService: ${message}`);
  }

  loadEventAnnotations(petid: number): Observable<EventAnnotation[]> {
    return this.http.get<EventAnnotation[]>(`${this.eventAnnotationtUrl}/${petid}`).pipe(
      tap((eventAnnotations) => {
        this.log(`getting events annotations data for pet ${petid}`);
        this.eventAnnotationsSource.next(eventAnnotations); // Update the current events annotation data
      }),
      catchError(this.handleError<EventAnnotation[]>('loadEventAnnotations', undefined))
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
