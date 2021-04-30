import { Parcela } from "./parcela.interface";

export class Titulo {
  id: any;
  numero: number;
  nomeDevedor: string;
  cpfDevedor: string;
  juros: number;
  multa: number;
  qtdParcelas: number;
  valorOriginal: number;
  diasEmAtraso: number;
  valorAtual: number;
  parcelas: Parcela[];
}