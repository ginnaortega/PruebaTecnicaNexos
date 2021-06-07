import { Component, OnInit } from '@angular/core';
import { HttpFactoryService } from '../services/http-factory.service';
import { ILibro } from './libro';

@Component({
  selector: 'app-libro',
  templateUrl: './libro.component.html',
  styleUrls: ['./libro.component.css']
})
export class LibroComponent implements OnInit {

  constructor(private httpFactory: HttpFactoryService) { }
  
  _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredBooks = this.listFilter ? this.performFilter(this.listFilter) : this.libros;
  }
  libros: ILibro[] = [];
  filteredBooks: ILibro[] = [];
  pageTitle = 'Consulta de Libros'

  ObtenerLibros() {
    this.httpFactory.get('Libro/ConsultarLibros', '')
      .then((resp: ILibro[]) => {
        this.libros = resp;
        this.filteredBooks = this.libros;
        console.log('respuesta', resp);
      }).catch((err) => {
        console.log('Error en la consulta de los libros');
      });
  }

  performFilter(filterBy: string): ILibro[] {
    filterBy = filterBy.toLocaleLowerCase();
   
    return this.libros.filter((hero : ILibro) =>{
        return hero.Titulo.toLowerCase().includes(filterBy)
              || hero.NombreAutor.toLowerCase().includes(filterBy)
              || hero.Anio === Number(filterBy);
      });
  }

  ngOnInit(): void {
    this.ObtenerLibros();
  }

}
