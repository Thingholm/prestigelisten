export type Json =
  | string
  | number
  | boolean
  | null
  | { [key: string]: Json | undefined }
  | Json[]

export type Database = {
  public: {
    Tables: {
      nation_points: {
        Row: {
          id: number
          nation_id: number | null
          points: number
        }
        Insert: {
          id?: number
          nation_id?: number | null
          points: number
        }
        Update: {
          id?: number
          nation_id?: number | null
          points?: number
        }
        Relationships: [
          {
            foreignKeyName: "nation_points_nation_id_fkey"
            columns: ["nation_id"]
            isOneToOne: true
            referencedRelation: "nations"
            referencedColumns: ["id"]
          },
        ]
      }
      nation_rankings_each_year: {
        Row: {
          id: number
          nation_id: number
          number_of_results: number
          placement: number | null
          points: number | null
          year: number
        }
        Insert: {
          id?: number
          nation_id: number
          number_of_results: number
          placement?: number | null
          points?: number | null
          year: number
        }
        Update: {
          id?: number
          nation_id?: number
          number_of_results?: number
          placement?: number | null
          points?: number | null
          year?: number
        }
        Relationships: [
          {
            foreignKeyName: "nation_rankings_each_year_nation_id_fkey"
            columns: ["nation_id"]
            isOneToOne: false
            referencedRelation: "nations"
            referencedColumns: ["id"]
          },
        ]
      }
      nation_rankings_each_year_accumulated: {
        Row: {
          id: number
          nation_id: number
          number_of_results: number
          placement: number | null
          points: number
          year: number
        }
        Insert: {
          id?: number
          nation_id: number
          number_of_results: number
          placement?: number | null
          points: number
          year: number
        }
        Update: {
          id?: number
          nation_id?: number
          number_of_results?: number
          placement?: number | null
          points?: number
          year?: number
        }
        Relationships: [
          {
            foreignKeyName: "nation_rankings_each_year_accumulated_nation_id_fkey"
            columns: ["nation_id"]
            isOneToOne: false
            referencedRelation: "nations"
            referencedColumns: ["id"]
          },
        ]
      }
      nations: {
        Row: {
          code: string
          id: number
          name: string
        }
        Insert: {
          code: string
          id?: number
          name: string
        }
        Update: {
          code?: string
          id?: number
          name?: string
        }
        Relationships: []
      }
      point_system: {
        Row: {
          id: number
          points: number
          race_classification_id: number
          result_type: string
        }
        Insert: {
          id?: number
          points: number
          race_classification_id: number
          result_type: string
        }
        Update: {
          id?: number
          points?: number
          race_classification_id?: number
          result_type?: string
        }
        Relationships: [
          {
            foreignKeyName: "point_system_race_classification_id_fkey"
            columns: ["race_classification_id"]
            isOneToOne: false
            referencedRelation: "race_classifications"
            referencedColumns: ["id"]
          },
        ]
      }
      previous_nationalities: {
        Row: {
          end_year: number | null
          id: number
          nation_id: number
          rider_id: number
          start_year: number | null
        }
        Insert: {
          end_year?: number | null
          id?: number
          nation_id: number
          rider_id: number
          start_year?: number | null
        }
        Update: {
          end_year?: number | null
          id?: number
          nation_id?: number
          rider_id?: number
          start_year?: number | null
        }
        Relationships: [
          {
            foreignKeyName: "previous_nationalities_nation_id_fkey"
            columns: ["nation_id"]
            isOneToOne: false
            referencedRelation: "nations"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "previous_nationalities_rider_id_fkey"
            columns: ["rider_id"]
            isOneToOne: false
            referencedRelation: "riders"
            referencedColumns: ["id"]
          },
        ]
      }
      race_calendar: {
        Row: {
          end_date: string
          id: number
          race_id: number
          start_date: string
        }
        Insert: {
          end_date: string
          id?: number
          race_id: number
          start_date: string
        }
        Update: {
          end_date?: string
          id?: number
          race_id?: number
          start_date?: string
        }
        Relationships: [
          {
            foreignKeyName: "race_calendar_race_id_fkey"
            columns: ["race_id"]
            isOneToOne: true
            referencedRelation: "races"
            referencedColumns: ["id"]
          },
        ]
      }
      race_classifications: {
        Row: {
          id: number
          name: string
        }
        Insert: {
          id?: number
          name: string
        }
        Update: {
          id?: number
          name?: string
        }
        Relationships: []
      }
      race_dates: {
        Row: {
          date: string
          id: number
          race_id: number
          stage: number | null
        }
        Insert: {
          date: string
          id?: number
          race_id: number
          stage?: number | null
        }
        Update: {
          date?: string
          id?: number
          race_id?: number
          stage?: number | null
        }
        Relationships: [
          {
            foreignKeyName: "race_dates_race_id_fkey"
            columns: ["race_id"]
            isOneToOne: false
            referencedRelation: "races"
            referencedColumns: ["id"]
          },
        ]
      }
      races: {
        Row: {
          active: boolean | null
          active_span: string | null
          color_hex: string | null
          id: number
          name: string
          nation_id: number | null
          race_classification_id: number
        }
        Insert: {
          active?: boolean | null
          active_span?: string | null
          color_hex?: string | null
          id?: number
          name: string
          nation_id?: number | null
          race_classification_id: number
        }
        Update: {
          active?: boolean | null
          active_span?: string | null
          color_hex?: string | null
          id?: number
          name?: string
          nation_id?: number | null
          race_classification_id?: number
        }
        Relationships: [
          {
            foreignKeyName: "races_nation_id_fkey"
            columns: ["nation_id"]
            isOneToOne: false
            referencedRelation: "nations"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "races_race_classification_id_fkey"
            columns: ["race_classification_id"]
            isOneToOne: false
            referencedRelation: "race_classifications"
            referencedColumns: ["id"]
          },
        ]
      }
      results: {
        Row: {
          id: number
          placement: number | null
          race_date_id: number | null
          race_id: number
          result_type: string
          rider_id: number
          year: number
        }
        Insert: {
          id?: never
          placement?: number | null
          race_date_id?: number | null
          race_id: number
          result_type: string
          rider_id: number
          year: number
        }
        Update: {
          id?: never
          placement?: number | null
          race_date_id?: number | null
          race_id?: number
          result_type?: string
          rider_id?: number
          year?: number
        }
        Relationships: [
          {
            foreignKeyName: "results_race_date_id_fkey"
            columns: ["race_date_id"]
            isOneToOne: false
            referencedRelation: "race_dates"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "results_race_id_fkey"
            columns: ["race_id"]
            isOneToOne: false
            referencedRelation: "races"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "results_rider_id_fkey"
            columns: ["rider_id"]
            isOneToOne: false
            referencedRelation: "riders"
            referencedColumns: ["id"]
          },
        ]
      }
      rider_points: {
        Row: {
          id: number
          points: number
          rider_id: number | null
        }
        Insert: {
          id?: number
          points: number
          rider_id?: number | null
        }
        Update: {
          id?: number
          points?: number
          rider_id?: number | null
        }
        Relationships: [
          {
            foreignKeyName: "rider_points_rider_id_fkey"
            columns: ["rider_id"]
            isOneToOne: true
            referencedRelation: "riders"
            referencedColumns: ["id"]
          },
        ]
      }
      rider_rankings_3_year_span: {
        Row: {
          end_year: number
          id: number
          placement: number | null
          points: number | null
          rider_id: number
          start_year: number
        }
        Insert: {
          end_year: number
          id?: number
          placement?: number | null
          points?: number | null
          rider_id: number
          start_year: number
        }
        Update: {
          end_year?: number
          id?: number
          placement?: number | null
          points?: number | null
          rider_id?: number
          start_year?: number
        }
        Relationships: [
          {
            foreignKeyName: "rider_rankings_3_year_span_rider_id_fkey"
            columns: ["rider_id"]
            isOneToOne: false
            referencedRelation: "riders"
            referencedColumns: ["id"]
          },
        ]
      }
      rider_rankings_each_decade: {
        Row: {
          decade: number
          id: number
          placement: number | null
          points: number | null
          rider_id: number
        }
        Insert: {
          decade: number
          id?: number
          placement?: number | null
          points?: number | null
          rider_id: number
        }
        Update: {
          decade?: number
          id?: number
          placement?: number | null
          points?: number | null
          rider_id?: number
        }
        Relationships: [
          {
            foreignKeyName: "rider_rankings_each_decade_rider_id_fkey"
            columns: ["rider_id"]
            isOneToOne: false
            referencedRelation: "riders"
            referencedColumns: ["id"]
          },
        ]
      }
      rider_rankings_each_year: {
        Row: {
          id: number
          placement: number | null
          points: number | null
          rider_id: number
          year: number
        }
        Insert: {
          id?: number
          placement?: number | null
          points?: number | null
          rider_id: number
          year: number
        }
        Update: {
          id?: number
          placement?: number | null
          points?: number | null
          rider_id?: number
          year?: number
        }
        Relationships: [
          {
            foreignKeyName: "rider_rankings_each_year_rider_id_fkey"
            columns: ["rider_id"]
            isOneToOne: false
            referencedRelation: "riders"
            referencedColumns: ["id"]
          },
        ]
      }
      rider_rankings_each_year_accumulated: {
        Row: {
          id: number
          placement: number | null
          points: number | null
          rider_id: number
          year: number
        }
        Insert: {
          id?: number
          placement?: number | null
          points?: number | null
          rider_id: number
          year: number
        }
        Update: {
          id?: number
          placement?: number | null
          points?: number | null
          rider_id?: number
          year?: number
        }
        Relationships: [
          {
            foreignKeyName: "rider_rankings_each_year_accumulated_rider_id_fkey"
            columns: ["rider_id"]
            isOneToOne: false
            referencedRelation: "riders"
            referencedColumns: ["id"]
          },
        ]
      }
      riders: {
        Row: {
          active: boolean | null
          birth_year: number | null
          first_name: string | null
          id: number
          last_name: string
          nation_id: number | null
          team_id: number | null
        }
        Insert: {
          active?: boolean | null
          birth_year?: number | null
          first_name?: string | null
          id?: number
          last_name: string
          nation_id?: number | null
          team_id?: number | null
        }
        Update: {
          active?: boolean | null
          birth_year?: number | null
          first_name?: string | null
          id?: number
          last_name?: string
          nation_id?: number | null
          team_id?: number | null
        }
        Relationships: [
          {
            foreignKeyName: "riders_nation_id_fkey"
            columns: ["nation_id"]
            isOneToOne: false
            referencedRelation: "nations"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "riders_team_id_fkey"
            columns: ["team_id"]
            isOneToOne: false
            referencedRelation: "teams"
            referencedColumns: ["id"]
          },
        ]
      }
      teams: {
        Row: {
          id: number
          name: string
        }
        Insert: {
          id?: number
          name: string
        }
        Update: {
          id?: number
          name?: string
        }
        Relationships: []
      }
    }
    Views: {
      [_ in never]: never
    }
    Functions: {
      [_ in never]: never
    }
    Enums: {
      result_type:
        | "Sejr"
        | "Top 3"
        | "Top 5"
        | "Top 10"
        | "Bjergtrøje"
        | "Pointtrøje"
        | "1. dag i førertrøjen"
        | "2. dag i førertrøjen"
        | "3. dag i førertrøjen"
        | "Øvrig dag i førertrøjen"
        | "Etapesejr"
        | "Guld"
        | "Sølv"
        | "Bronze"
    }
    CompositeTypes: {
      [_ in never]: never
    }
  }
}

type PublicSchema = Database[Extract<keyof Database, "public">]

export type Tables<
  PublicTableNameOrOptions extends
    | keyof (PublicSchema["Tables"] & PublicSchema["Views"])
    | { schema: keyof Database },
  TableName extends PublicTableNameOrOptions extends { schema: keyof Database }
    ? keyof (Database[PublicTableNameOrOptions["schema"]]["Tables"] &
        Database[PublicTableNameOrOptions["schema"]]["Views"])
    : never = never,
> = PublicTableNameOrOptions extends { schema: keyof Database }
  ? (Database[PublicTableNameOrOptions["schema"]]["Tables"] &
      Database[PublicTableNameOrOptions["schema"]]["Views"])[TableName] extends {
      Row: infer R
    }
    ? R
    : never
  : PublicTableNameOrOptions extends keyof (PublicSchema["Tables"] &
        PublicSchema["Views"])
    ? (PublicSchema["Tables"] &
        PublicSchema["Views"])[PublicTableNameOrOptions] extends {
        Row: infer R
      }
      ? R
      : never
    : never

export type TablesInsert<
  PublicTableNameOrOptions extends
    | keyof PublicSchema["Tables"]
    | { schema: keyof Database },
  TableName extends PublicTableNameOrOptions extends { schema: keyof Database }
    ? keyof Database[PublicTableNameOrOptions["schema"]]["Tables"]
    : never = never,
> = PublicTableNameOrOptions extends { schema: keyof Database }
  ? Database[PublicTableNameOrOptions["schema"]]["Tables"][TableName] extends {
      Insert: infer I
    }
    ? I
    : never
  : PublicTableNameOrOptions extends keyof PublicSchema["Tables"]
    ? PublicSchema["Tables"][PublicTableNameOrOptions] extends {
        Insert: infer I
      }
      ? I
      : never
    : never

export type TablesUpdate<
  PublicTableNameOrOptions extends
    | keyof PublicSchema["Tables"]
    | { schema: keyof Database },
  TableName extends PublicTableNameOrOptions extends { schema: keyof Database }
    ? keyof Database[PublicTableNameOrOptions["schema"]]["Tables"]
    : never = never,
> = PublicTableNameOrOptions extends { schema: keyof Database }
  ? Database[PublicTableNameOrOptions["schema"]]["Tables"][TableName] extends {
      Update: infer U
    }
    ? U
    : never
  : PublicTableNameOrOptions extends keyof PublicSchema["Tables"]
    ? PublicSchema["Tables"][PublicTableNameOrOptions] extends {
        Update: infer U
      }
      ? U
      : never
    : never

export type Enums<
  PublicEnumNameOrOptions extends
    | keyof PublicSchema["Enums"]
    | { schema: keyof Database },
  EnumName extends PublicEnumNameOrOptions extends { schema: keyof Database }
    ? keyof Database[PublicEnumNameOrOptions["schema"]]["Enums"]
    : never = never,
> = PublicEnumNameOrOptions extends { schema: keyof Database }
  ? Database[PublicEnumNameOrOptions["schema"]]["Enums"][EnumName]
  : PublicEnumNameOrOptions extends keyof PublicSchema["Enums"]
    ? PublicSchema["Enums"][PublicEnumNameOrOptions]
    : never
