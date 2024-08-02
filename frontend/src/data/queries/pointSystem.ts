import { useQuery, useQueryClient } from "@tanstack/react-query"
import supabase from "../supabaseClient";

export const usePointSystem = () => {
    const queryClient = useQueryClient();

    const queryFn = async () => {
        let { data, error } = await supabase
            .from("point_system")
            .select("*")
        return data;
    }

    const query = useQuery({
        queryKey: ["point_system"],
        queryFn: queryFn
    });

    return query;
}