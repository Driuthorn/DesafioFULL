import { Pipe, PipeTransform } from '@angular/core'

@Pipe({
    name: 'filter',
    pure: false
})
export class FilterPipe implements PipeTransform {
    transform(items: any[], params: any, arg: string): any {
        if (!items || !params) {
            return items;
        }

        return (items || []).filter(x => params.split(',').some(key => x.hasOwnProperty(key) && new RegExp(arg, 'gi').test(x[key])));
    }
}