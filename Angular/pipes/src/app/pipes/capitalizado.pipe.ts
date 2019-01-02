import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'capitalizado'})
export class CapitalizadoPipe implements PipeTransform {
    transform(value: string, todas: boolean = true): any {
        value = value.toLocaleLowerCase();
        const nombre = value.split(' ');
        if (todas) {
            for (let i = 0; i < nombre.length; i++) {
                nombre[i] = nombre[i][0].toUpperCase() + nombre[i].substr(1);
            }
        } else {
            nombre[0] = nombre[0][0].toLocaleUpperCase() + nombre[0].substr(1);
        }

        return nombre.join(' ');
    }
}
