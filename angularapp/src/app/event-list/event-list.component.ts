import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { EventAnnotation } from './models/eventAnnotation';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.scss'
})
export class EventListComponent {
  @Input() currentEventAnnotations: EventAnnotation[] = [];

  displayedColumns: string[] = ['date', 'eventType', 'note'];

  dataSource = new MatTableDataSource<EventAnnotation>(this.currentEventAnnotations);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['currentEventAnnotations']) {
      // Handle the change in currentEventAnnotations here
      this.dataSource.data = this.currentEventAnnotations;
    }
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}
