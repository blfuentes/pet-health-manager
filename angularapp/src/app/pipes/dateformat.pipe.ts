import { Pipe, PipeTransform } from '@angular/core';
import { format } from 'date-fns';

@Pipe({
  name: 'dateFormat',
})
export class DateFormatPipe implements PipeTransform {
  transform(value: Date | string, dateFormat: string = 'yyyy-MM-dd'): string {
    if (!value) return '';
    const date = value instanceof Date ? value : new Date(value);
    return format(date, dateFormat);
  }
}
