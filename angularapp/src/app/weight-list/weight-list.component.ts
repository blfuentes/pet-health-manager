import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { Weight } from './models/weight';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-weight-list',
  templateUrl: './weight-list.component.html',
  styleUrl: './weight-list.component.css',
})
export class WeightListComponent {
  @Input() currentWeights: Weight[] = [];

  displayedColumns: string[] = ['date', 'weight'];

  dataSource = new MatTableDataSource<Weight>(this.currentWeights);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['currentWeights']) {
      // Handle the change in currentWeights here
      this.dataSource.data = this.currentWeights;
    }
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}
