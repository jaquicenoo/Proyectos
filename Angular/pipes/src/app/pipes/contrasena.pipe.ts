import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'contrasena'
})
export class ContrasenaPipe implements PipeTransform {

  transform(value: string, activar: boolean = true): string {
    if (activar) {
      let salidas = '';
      for (let i = 0; i < value.length; i++) {
        salidas += '*';
      }
    return salidas;
    } else {
      return value;
    }
  }

}
